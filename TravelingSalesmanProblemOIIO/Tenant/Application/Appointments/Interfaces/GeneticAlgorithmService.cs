using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    public class GeneticAlgorithmService : IGeneticAlgorithmService
    {

        public GeneticAlgorithmService()
        {

        }

        public double CalcRouteCost(List<Appointment> appointments, int[] order)
        {
            throw new NotImplementedException();
        }

        public void Calculate(List<Appointment> appointments)
        {
            throw new NotImplementedException();
        }

        public void CalculateCostMatrix()
        {
            throw new NotImplementedException();
        }

        public double CalculateDistanceBetweenTwo(Appointment firstAppointment, Appointment secondAppointment)
        {
            throw new NotImplementedException();
        }

        public void CalculateFitness()
        {
            throw new NotImplementedException();
        }

        public void CalculateShortestOfPopulation()
        {
            throw new NotImplementedException();
        }

        public int[] CrossOver(int[] orderA, int[] orderB)
        {
            throw new NotImplementedException();
        }

        public void GeneratePopulation()
        {
            throw new NotImplementedException();
        }

        public void Mutate(int[] order, int mutationRate)
        {
            throw new NotImplementedException();
        }

        public void NextGeneration()
        {
            throw new NotImplementedException();
        }

        public void NormalizeFitness()
        {
            throw new NotImplementedException();
        }

        public void Selection(int[][] population, double[] probability)
        {
            throw new NotImplementedException();
        }

        public int[] ShuffleInitialPopulation(int[] order, int amountShuffles)
        {
            throw new NotImplementedException();
        }

        public void SwapAppointments(int[] order, int numberOne, int numberTwo)
        {
            throw new NotImplementedException();
        }
    }
}
