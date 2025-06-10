package com.company;

public class SequenceThread extends Thread {
    private final int id;
    private final int step;
    private volatile boolean canStop = false;

    private long sum = 0;
    private long count = 0;

    public SequenceThread(int id, int step) {
        this.id = id;
        this.step = step;
    }

    /*public void allowStop() {
        this.canStop = true;
    }*/

    public synchronized void allowStop() {
        this.canStop = true;
    }

    private synchronized boolean getStop() {
        return canStop;
    }

    @Override //`coz i can
    public void run() {
        int current = 0;

        while (!getStop()) {
            sum += current;
            current += step;
            count++;
        }

        System.out.println("Потік #" + id + " | Сума: " + sum + " | Доданків: " + count);
    }
}
