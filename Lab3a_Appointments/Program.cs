Appointments a = new Appointments();

public class Appointments {
    int[,] timeSlots;
    public Appointments() {
        timeSlots = new int[8, 60]; //[Periods, Minutes]
    }

    public bool isMinuteFree(int period, int minute) {
        if(period < 1 || period > timeSlots.Length || minute < 0 || minute > (timeSlots.Length-1)) {
            return false;
        }
        return timeSlots[period-1, minute] == 0;
    }

}


