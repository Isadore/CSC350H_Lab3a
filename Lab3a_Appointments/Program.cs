﻿public class Test {
    public static void Main(string[] args) {
        Appointments a = new();
        
        a.displayReservedTimes();

        for (int i = 1; i <= 8; i++) {
            bool aptMade = a.makeAppointment(i,i,10);
            Console.WriteLine($"Period: {i} : {aptMade}");
        }

        a.displayReservedTimes();
        
    }
}

public class Appointments {
    int[,] timeSlots;
    public Appointments() {
        timeSlots = new int[8, 60]; //[Periods, Minutes]
        Random rnd = new Random();
        for(int i = 0; i < 10; i++) {
            int p = rnd.Next(1, 9);
            makeAppointment(p,p, rnd.Next(5,31));
        }
    }

    public bool isMinuteFree(int period, int minute) {
        if(period < 1 || period > timeSlots.Length || minute < 0 || minute > (timeSlots.Length-1)) {
            return false;
        }
        return timeSlots[period-1, minute] == 0;
    }
    public void reserveBlock(int period, int startMinute, int duration) {
         if(period < 1 || period > timeSlots.Length || startMinute < 0 || startMinute > (timeSlots.Length-1) || duration < 1 || duration > 60) {
            return;
        }
        for (int x = 0; x < duration; x++) {
            timeSlots[period-1,startMinute+x] = 1;
        }
    }

    public int findFreeBlock(int period, int duration) {
        int durationFound = 0;
        int startMinute = -1;
        for(int i = 0; i <= 59; i++) {
            if(isMinuteFree(period, i)) {
                durationFound++;
                if(startMinute == -1) {
                    startMinute = i;
                }
            } else {
                startMinute = -1;
                durationFound = 0;
            }
            if(durationFound == duration) {
                return startMinute;
            }
        }
        return -1;
    }

    public bool makeAppointment (int startPeriod, int endPeriod, int duration) {
        for(int x = startPeriod; x <= endPeriod; x++) {
            int block = findFreeBlock(x, duration);
            if (block != -1) {
                reserveBlock(x, block, duration);
                return true;
            } 
        }
        return false;
    }

    public void displayReservedTimes() {
        Console.WriteLine("- = Minute Available, | = Minute Unavailable");
        for(int i = 0; i < 8; i++) {
            Console.Write("Period " + (i+1) + " Availability: ");
            for(int j = 0; j < 60; j++) {
                Console.Write((timeSlots[i, j] == 1 ? "-" : "|") + "");
            }
            Console.WriteLine();
        }
    }

}


