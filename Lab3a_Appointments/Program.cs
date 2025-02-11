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
    public void reserveBlock(int period, int startMinute, int duration) {
         if(period < 1 || period > timeSlots.Length || startMinute < 0 || startMinute > (timeSlots.Length-1) || duration < 1 || duration > 60) {
            return;
        }
        for (int x = 0; x < duration; x++) {
            timeSlots[period-1,startMinute+x] = 1;
        }
    }

}


