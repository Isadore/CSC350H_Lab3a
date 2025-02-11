Appointments a = new Appointments();

public class Appointments {
    int[,] timeSlots;
    public Appointments() {
        timeSlots = new int[8, 60];
    }
public void reserveBlock(int period, int startMinute, int duration) {
    for (int x = 0; x < duration; x++) {
        timeSlots[period=1,startMinute+x] = 1;
    }
}

}


