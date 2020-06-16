CREATE TABLE public."ComprasDivisas"
(
    id serial NOT NULL,
    "idUsuario" bigint NOT NULL,
    divisa text NOT NULL,
    "montoComprado" numeric(8,3) NOT NULL,
    "fechaCompra" date NOT NULL default CURRENT_DATE,
    PRIMARY KEY (id)
)
WITH (
    OIDS = FALSE
);

ALTER TABLE public."ComprasDivisas"
    OWNER to postgres;