using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    public interface IGeneticAlgorithmService
    {
        List<AppointmentRequest> Calculate(List<AppointmentRequest> appointments, int populationSize, int amountGenerations);
        double[][] CalculateCostMatrix();
        double[] calculateCostArray();
        double CalculateDistanceBetweenTwo(AppointmentRequest firstAppointment, AppointmentRequest secondAppointment);
        int[][] GeneratePopulation();
        void CalculateShortestOfPopulation();
        double CalcRouteCost(List<AppointmentRequest> appointments, int[] order);
        void NextGeneration();
        int[] CrossOver(int[] orderA, int[] orderB);
        int[] Mutate(int[] order, int mutationRate);
        int[] Selection(int[][] population, double[] probability);
        int[] ShuffleInitialPopulation(int[] order, int amountShuffles);
        int[] SwapAppointments(int[] order, int numberOne, int numberTwo);
        void CalculateFitness(List<AppointmentRequest> appointments, int[][] population);
        double[] NormalizeFitness(double[] fitness);
    }
}
