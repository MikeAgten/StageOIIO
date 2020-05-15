using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    public interface IGeneticAlgorithmService
    {
        List<Appointment> Calculate(List<Appointment> appointments, int populationSize, int amountGenerations);
        double[][] CalculateCostMatrix();
        double[] calculateCostArray();
        double CalculateDistanceBetweenTwo(Appointment firstAppointment, Appointment secondAppointment);
        int[][] GeneratePopulation();
        void CalculateShortestOfPopulation();
        double CalcRouteCost(List<Appointment> appointments, int[] order);
        void NextGeneration();
        int[] CrossOver(int[] orderA, int[] orderB);
        int[] Mutate(int[] order, int mutationRate);
        int[] Selection(int[][] population, double[] probability);
        int[] ShuffleInitialPopulation(int[] order, int amountShuffles);
        int[] SwapAppointments(int[] order, int numberOne, int numberTwo);
        void CalculateFitness(List<Appointment> appointments, int[][] population);
        double[] NormalizeFitness(double[] fitness);
    }
}
