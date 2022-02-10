package com.company;

public class Coche {
    private String _brand;
    private String _model;
    private String _color;
    private int _kilometres;

    public Coche(String brand, String model, String color, int kilometres) {
        _brand = brand;
        _model = model;
        _color = color;
        _kilometres = kilometres;
    }

    public String getColor() {
        return _color;
    }

    public void setColor(String color) {
        _color = color;
    }

    public String getModel() {
        return _model;
    }

    public void setModel(String model) {
        _model = model;
    }

    public String getBrand() {
        return _brand;
    }

    public void setBrand(String brand) {
        _brand = brand;
    }

    public int getKilometres() {
        return _kilometres;
    }

    public void setKilometres(int kilometres) {
        _kilometres = kilometres;
    }

    @Override
    public String toString() {
        return "Coche{" +
                "brand='" + _brand + '\'' +
                ", model='" + _model + '\'' +
                ", color='" + _color + '\'' +
                ", kilometres=" + _kilometres +
                '}';
    }
}
