import java.util.ArrayList;
import java.util.List;

public class Main {
    public static void main(String[] args) {
        int bufferSize = 5;
        int totalItems = 20;
        int producers = 2;
        int consumers = 4;

        Manager manager = new Manager(bufferSize);
        List<Thread> threads = new ArrayList<>();

        for (int i = 0; i < producers; i++) {
            Thread t = new Thread(() -> {
                Producer producer = new Producer(manager, totalItems / producers);
                producer.run();
            }, "Producer-" + i);
            threads.add(t);
            t.start();
        }

        for (int i = 0; i < consumers; i++) {
            Thread t = new Thread(() -> {
                Consumer consumer = new Consumer(manager, totalItems / consumers);
                consumer.run();
            }, "Consumer-" + i);
            threads.add(t);
            t.start();
        }

        for (Thread t : threads) {
            try {
                t.join();
            } catch (InterruptedException e) {
                Thread.currentThread().interrupt();
            }
        }

        System.out.println("All producers and consumers have completed.");
    }
}
