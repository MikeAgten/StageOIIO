using AppointmentProj.Domain;
using CompareAlgorithmsApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    public class GeneticAlgorithmService : IGeneticAlgorithmService
    {
        int populationSize;
        int amountShuffles = 30;
        int amountGenerations;

        int currentGeneration = 0;
        double recordRouteCost = 99999999; //represents infinite to start with

        private List<Appointment> appointments;
        private List<Appointment> sortedAppointments;

        private int[] bestPathEver;
        private double[][] costMatrix;
        private int[][] population;
        private int[] order;
        private double[] fitness;

        Random rand;

        public List<Appointment> Calculate(List<Appointment> appointments, int populationSize, int amountGenerations)
        {
            this.appointments = appointments;
            this.populationSize = populationSize;
            this.amountGenerations = amountGenerations;
            sortedAppointments = new List<Appointment>();
            rand = new Random();
            costMatrix = CalculateCostMatrix();
            printMatrix(costMatrix);
            population = GeneratePopulation();
            printPopulationMatrix(population);
            CalculateShortestOfPopulation();
            startAlgorithmLoop();
            sortAppointments();
            return sortedAppointments;
        }

        private void sortAppointments()
        {
            for(int appointmentIndex = 0; appointmentIndex < bestPathEver.Length; appointmentIndex++)
            {
                sortedAppointments.Add(appointments[bestPathEver[appointmentIndex]]);
            }
        }

        private void startAlgorithmLoop()
        {
            while (amountGenerations > currentGeneration)
            {
                CalculateFitness(appointments, population);
                fitness = NormalizeFitness(fitness);
                NextGeneration();
                CalculateShortestOfPopulation();
                currentGeneration++;
            }
            Console.WriteLine("Reached the end of the algorithm with routecost: " + recordRouteCost);
        }

        public double CalcRouteCost(List<Appointment> appointments, int[] order)
        {
            var sum = 0d;
            for (int orderIndex = 0; orderIndex < order.Length - 1; orderIndex++)
            {
                var addressAIndex = order[orderIndex];
                var addressBIndex = order[orderIndex + 1];
                var costForIndex = costMatrix[addressAIndex][addressBIndex];
                sum += costForIndex;
            }
            var firstAddress = order[0];
            var finalAddress = order[order.Length - 1];
            sum += costMatrix[firstAddress][finalAddress];
            return sum;
        }

        public double[][] CalculateCostMatrix()
        {
            var costMatrix = new Double[appointments.Count][];
            for (int row = 0; row < appointments.Count; row++)
            {
                var costFromPoint = new Double[appointments.Count];
                for (int column = 0; column < appointments.Count; column++)
                {
                    costFromPoint[column] = CalculateDistanceBetweenTwo(appointments[row], appointments[column]);
                }
                costMatrix[row] = costFromPoint;
            }
            return costMatrix;
        }

        public double CalculateDistanceBetweenTwo(Appointment firstAppointment, Appointment secondAppointment)
        {
            return Math.Sqrt(Math.Pow(firstAppointment.Longitude - secondAppointment.Longitude, 2) + Math.Pow(firstAppointment.Latitude - secondAppointment.Latitude, 2));
        }

        public void CalculateShortestOfPopulation()
        {
            for (int populationIndex = 0; populationIndex < population.Length; populationIndex++)
            {
                var routeCost = CalcRouteCost(appointments, population[populationIndex]);
                if (routeCost < recordRouteCost)
                {
                    recordRouteCost = routeCost;
                    bestPathEver = population[populationIndex];
                    var route = population[populationIndex];
                    string order = "";
                    for (int j = 0; j < bestPathEver.Length; j++)
                    {
                        order += route[j] + ", ";
                    }
                    Console.WriteLine("Beste volgorde = " + order);
                }
            }
        }

        public int[] CrossOver(int[] orderA, int[] orderB)
        {
            var start = rand.Next(0, orderA.Length);
            var end = rand.Next(start + 1, orderA.Length);
            List<int> newOrder = orderA.Skip(start).Take(end).ToList();
            var lengthB = orderB.Length;
            for (int i = 0; i < lengthB; i++)
            {
                var address = orderB[i];
                if (!newOrder.Contains(address))
                {
                    newOrder.Add(address);
                }
            }
            return newOrder.ToArray();
        }

        public int[][] GeneratePopulation()
        {
            var population = new int[populationSize][];
            order = new int[appointments.Count];
            var shuffledOrder = new int[appointments.Count];
            for (int orderIndex = 0; orderIndex < order.Length; orderIndex++)
            {
                //filling the order with 1,2,3,4,5,...
                order[orderIndex] = orderIndex;
            }
            for (int populationIndex = 0; populationIndex < population.Length; populationIndex++)
            {
                shuffledOrder = ShuffleInitialPopulation(order, amountShuffles);
                population[populationIndex] = Cloner.DeepClone(shuffledOrder);
            }
            return population;
        }

        public int[] Mutate(int[] order, int mutationRate)
        {
            var swappedOrder = new int[order.Length];
            for (int i = 0; i < mutationRate; i++)
            {
                var indexA = rand.Next(0, order.Length);
                var indexB = (indexA + 1) % appointments.Count;
                swappedOrder = SwapAppointments(order, indexA, indexB);
            }
            return swappedOrder;
        }

        public void NextGeneration()
        {
            var newPopulation = new int[populationSize][];
            for (var i = 0; i < population.Length; i++)
            {
                var orderA = Selection(population, fitness); //pak een oplossing uit de populatie
                var orderB = Selection(population, fitness); //pak een oplossing uit de populatie
                var order = CrossOver(orderA, orderB);
                order = Mutate(order, 1);
                newPopulation[i] = order;
            }
            population = newPopulation;
        }

        public void CalculateFitness(List<Appointment> appointments, int[][] population)
        {
            fitness = new double[appointments.Count];
            for (var populationIndex = 0; populationIndex < appointments.Count; populationIndex++)
            {
                var d = CalcRouteCost(appointments, population[populationIndex]);
                if (d < recordRouteCost)
                {
                    recordRouteCost = d;
                }
                fitness[populationIndex] = 1 / (d + 1);
            }
        }

        public double[] NormalizeFitness(double[] fitness)
        {
            var sum = 0d;
            for (var i = 0; i < fitness.Length; i++)
            {
                sum += fitness[i];
            }
            for (var i = 0; i < fitness.Length; i++)
            {
                fitness[i] = fitness[i] / sum;
            }
            return fitness;
        }

        public int[] Selection(int[][] population, double[] probability)
        {
            var index = 0;
            double r = rand.NextDouble();
            while (r > 0)
            {
                r = r - probability[index];
                index++;
            }
            index--;
            return (int[])population[index].Clone();
        }

        public int[] ShuffleInitialPopulation(int[] order, int amountShuffles)
        {
            var swappedOrder = new int[order.Length];
            for (int i = 0; i < amountShuffles; i++)
            {
                var indexA = rand.Next(0, order.Length);
                var indexB = rand.Next(0, order.Length);
                swappedOrder = SwapAppointments(order, indexA, indexB);
            }
            return swappedOrder;
        }

        public int[] SwapAppointments(int[] order, int numberOne, int numberTwo)
        {
            var swapAddress = order[numberOne];
            order[numberOne] = order[numberTwo];
            order[numberTwo] = swapAddress;
            return order;
        }

        public void printMatrix(double[][] matrix)
        {
            for (int row = 0; row < matrix.Length; row++)
            {
                for (int column = 0; column < matrix.Length; column++)
                {
                    Console.Write(Math.Round(matrix[row][column], 3) + " --- ");
                }
                Console.WriteLine();
            }
        }

        public void printPopulationMatrix(int[][] matrix)
        {
            Console.WriteLine("First 20 orders of population: ");
            for (int row = 0; row < 20; row++)
            {
                for (int column = 0; column < appointments.Count; column++)
                {
                    Console.Write(matrix[row][column] + " --- ");
                }
                Console.WriteLine();
            }
        }
    }
}
