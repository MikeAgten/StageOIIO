using AppointmentProj.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppointmentProj.Application.Appointments.Interfaces
{
    interface IGeneticAlgorithmService
    {
        void Calculate(List<Appointment> appointments);
        void CalculateCostMatrix();
        double CalculateDistanceBetweenTwo(Appointment firstAppointment, Appointment secondAppointment);
        void GeneratePopulation();
        void CalculateShortestOfPopulation();
        double CalcRouteCost(List<Appointment> appointments, int[] order);
        void NextGeneration();
        int[] CrossOver(int[] orderA, int[] orderB);
        void Mutate(int[] order, int mutationRate);
        void Selection(int[][] population, double[] probability);
        int[] ShuffleInitialPopulation(int[] order, int amountShuffles);
        void SwapAppointments(int[] order, int numberOne, int numberTwo);
        void CalculateFitness();
        void NormalizeFitness();
    }
}
