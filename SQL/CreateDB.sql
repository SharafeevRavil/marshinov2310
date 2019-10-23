CREATE DATABASE arshinov2310
    WITH
    OWNER = postgres
    ENCODING = 'UTF8'
    CONNECTION LIMIT = -1;

CREATE TABLE products
(
    id          SERIAL PRIMARY KEY,
    name        varchar(80),
    description varchar(80),
    price       int
);

INSERT INTO products (name, description, price)
VALUES ('Product1', 'Description1', 1000),
       ('Product2', 'Description2', 2000),
       ('Product3', 'Description3', 3000)
