package com.autoverleih.Controller;

import com.autoverleih.Car;
import org.springframework.web.bind.annotation.GetMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.bind.annotation.RestController;

import java.util.ArrayList;
import java.util.List;
import java.util.concurrent.atomic.AtomicLong;

@RestController
public class CarController {
    private static List<Car> cars = new ArrayList<Car>();
    public CarController() {
        cars.add(new Car(1, "Audi"));
        cars.add(new Car(2, "BMW"));
    }

    @GetMapping("/Cars")
    public List<Car> cars() {
        return cars;
    }
}
