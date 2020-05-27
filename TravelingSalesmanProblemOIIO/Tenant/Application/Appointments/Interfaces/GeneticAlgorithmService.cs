using AppointmentProj.Domain;
using CompareAlgorithmsApplication;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    public class GeneticAlgorithmService : IGeneticAlgorithmService
    {
        int populationSize;
        readonly int amountShuffles = 30;
        int amountGenerations;

        int currentGeneration = 0;
        double recordRouteCost = double.MaxValue; //represents infinite to start with

        private List<AppointmentRequest> appointmentRequests;
        private List<AppointmentRequest> sortedAppointmentRequests;

        private int[] bestPathEver;
        private double[][] costMatrix;
        private int[][] population;
        private int[] order;
        private double[] fitness;

        Random rand;

        public List<AppointmentRequest> Calculate(List<AppointmentRequest> appointmentRequests, int populationSize, int amountGenerations)
        {
            this.appointmentRequests = appointmentRequests;
            this.populationSize = populationSize;
            this.amountGenerations = amountGenerations;
            sortedAppointmentRequests = new List<AppointmentRequest>();
            rand = new Random();
            costMatrix = CalculateCostMatrix();
            PrintMatrix(costMatrix);
            population = GeneratePopulation();
            PrintPopulationMatrix(population);
            CalculateShortestOfPopulation();
            StartAlgorithmLoop();
            bestPathEver = ShiftAppointments(bestPathEver);
            SortAppointments();
            return sortedAppointmentRequests;
        }

        private int[] ShiftAppointments(int[] bestPathEver)
        {
            int[] currentPath = bestPathEver;
            int[] shiftedPath = new int[bestPathEver.Length];
            while (currentPath[0] != 0)
            {
                for (int i = 0; i < currentPath.Length - 1; i++)
                {
                    shiftedPath[i] = currentPath[i + 1];
                }
                shiftedPath[^1] = currentPath[0];
                currentPath = (int[])shiftedPath.Clone();
            }
            return shiftedPath;
        }

        public double[] CalculateCostArray()
        {
            var costArray = new double[appointmentRequests.Count];
            for (int appointmentIndex = 0; appointmentIndex < bestPathEver.Length - 1; appointmentIndex++)
            {
                costArray[appointmentIndex] = costMatrix[bestPathEver[appointmentIndex]][bestPathEver[appointmentIndex + 1]] / 0.0075;
            }
            costArray[^1] = costMatrix[bestPathEver[costArray.Length - 1]][bestPathEver[0]] / 0.0065;
            return costArray;
        }

        private void SortAppointments()
        {
            for (int appointmentIndex = 0; appointmentIndex < bestPathEver.Length; appointmentIndex++)
            {
                sortedAppointmentRequests.Add(appointmentRequests[bestPathEver[appointmentIndex]]);
            }
        }

        private void StartAlgorithmLoop()
        {
            while (amountGenerations > currentGeneration)
            {
                CalculateFitness(appointmentRequests, population);
                fitness = NormalizeFitness(fitness);
                NextGeneration();
                CalculateShortestOfPopulation();
                currentGeneration++;
            }
            Console.WriteLine("Reached the end of the algorithm with routecost: " + recordRouteCost);
        }

        public double CalcRouteCost(List<AppointmentRequest> appointments, int[] order)
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
            var finalAddress = order[^1];
            sum += costMatrix[firstAddress][finalAddress];
            return sum;
        }

        public double[][] CalculateCostMatrix()
        {
            var costMatrix = new Double[appointmentRequests.Count][];
            for (int row = 0; row < appointmentRequests.Count; row++)
            {
                var costFromPoint = new Double[appointmentRequests.Count];
                for (int column = 0; column < appointmentRequests.Count; column++)
                {
                    costFromPoint[column] = CalculateDistanceBetweenTwo(appointmentRequests[row], appointmentRequests[column]);
                }
                costMatrix[row] = costFromPoint;
            }
            return costMatrix;
        }

        public double CalculateDistanceBetweenTwo(AppointmentRequest firstAppointment, AppointmentRequest secondAppointment)
        {
            return Math.Sqrt(Math.Pow(firstAppointment.Longitude - secondAppointment.Longitude, 2) + Math.Pow(firstAppointment.Latitude - secondAppointment.Latitude, 2));
        }

        public void CalculateShortestOfPopulation()
        {
            for (int populationIndex = 0; populationIndex < population.Length; populationIndex++)
            {
                var routeCost = CalcRouteCost(appointmentRequests, population[populationIndex]);
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
            order = new int[appointmentRequests.Count];
            for (int orderIndex = 0; orderIndex < order.Length; orderIndex++)
            {
                //filling the order with 1,2,3,4,5,...
                order[orderIndex] = orderIndex;
            }
            for (int populationIndex = 0; populationIndex < population.Length; populationIndex++)
            {
                var shuffledOrder = ShuffleInitialPopulation(order, amountShuffles);
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
                var indexB = (indexA + 1) % appointmentRequests.Count;
                swappedOrder = SwapAppointments(order, indexA, indexB);
            }
            return swappedOrder;
        }

        public void NextGeneration()
        {
            var newPopulation = new int[populationSize][];
            for (var i = 0; i < population.Length; i++)
            {
                var orderA = Selection(population, fitness);
                var orderB = Selection(population, fitness);
                var order = CrossOver(orderA, orderB);
                order = Mutate(order, 1);
                newPopulation[i] = order;
            }
            population = newPopulation;
        }

        public void CalculateFitness(List<AppointmentRequest> appointments, int[][] population)
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
                r -= probability[index];
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

        public void PrintMatrix(double[][] matrix)
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

        public void PrintPopulationMatrix(int[][] matrix)
        {
            Console.WriteLine("First 20 orders of population: ");
            for (int row = 0; row < 20; row++)
            {
                for (int column = 0; column < appointmentRequests.Count; column++)
                {
                    Console.Write(matrix[row][column] + " --- ");
                }
                Console.WriteLine();
            }
        }
    }
}
