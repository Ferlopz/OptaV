PGDMP     )    :                |            Factura    15.2    15.2                0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            	           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            
           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false                       1262    24590    Factura    DATABASE     |   CREATE DATABASE "Factura" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE_PROVIDER = libc LOCALE = 'Spanish_Spain.1252';
    DROP DATABASE "Factura";
                postgres    false            �            1259    40977    cliente    TABLE     L  CREATE TABLE public.cliente (
    id integer NOT NULL,
    id_banco integer NOT NULL,
    nombre character varying NOT NULL,
    apellido character varying NOT NULL,
    documento character(10) NOT NULL,
    direccion character varying,
    mail character varying,
    celular character varying(10),
    estado character varying
);
    DROP TABLE public.cliente;
       public         heap    postgres    false            �            1259    40999    cliente_idcliente_seq    SEQUENCE     ~   CREATE SEQUENCE public.cliente_idcliente_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public.cliente_idcliente_seq;
       public          postgres    false    214                       0    0    cliente_idcliente_seq    SEQUENCE OWNED BY     H   ALTER SEQUENCE public.cliente_idcliente_seq OWNED BY public.cliente.id;
          public          postgres    false    216            �            1259    40986    factura    TABLE     k  CREATE TABLE public.factura (
    id integer NOT NULL,
    id_cliente integer NOT NULL,
    nro_factura character varying,
    fecha_hora character varying,
    total_letras character varying NOT NULL,
    sucursal character varying,
    total_iva5 integer NOT NULL,
    total integer NOT NULL,
    total_iva10 integer NOT NULL,
    total_iva integer NOT NULL
);
    DROP TABLE public.factura;
       public         heap    postgres    false            �            1259    41000    factura_idfactura_seq    SEQUENCE     ~   CREATE SEQUENCE public.factura_idfactura_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public.factura_idfactura_seq;
       public          postgres    false    215                       0    0    factura_idfactura_seq    SEQUENCE OWNED BY     H   ALTER SEQUENCE public.factura_idfactura_seq OWNED BY public.factura.id;
          public          postgres    false    217            j           2604    41001 
   cliente id    DEFAULT     o   ALTER TABLE ONLY public.cliente ALTER COLUMN id SET DEFAULT nextval('public.cliente_idcliente_seq'::regclass);
 9   ALTER TABLE public.cliente ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    216    214            k           2604    41002 
   factura id    DEFAULT     o   ALTER TABLE ONLY public.factura ALTER COLUMN id SET DEFAULT nextval('public.factura_idfactura_seq'::regclass);
 9   ALTER TABLE public.factura ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    217    215                      0    40977    cliente 
   TABLE DATA           n   COPY public.cliente (id, id_banco, nombre, apellido, documento, direccion, mail, celular, estado) FROM stdin;
    public          postgres    false    214   �                 0    40986    factura 
   TABLE DATA           �   COPY public.factura (id, id_cliente, nro_factura, fecha_hora, total_letras, sucursal, total_iva5, total, total_iva10, total_iva) FROM stdin;
    public          postgres    false    215   "                  0    0    cliente_idcliente_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public.cliente_idcliente_seq', 2, true);
          public          postgres    false    216                       0    0    factura_idfactura_seq    SEQUENCE SET     D   SELECT pg_catalog.setval('public.factura_idfactura_seq', 1, false);
          public          postgres    false    217            r           2606    40992    factura pk_factura 
   CONSTRAINT     ]   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT pk_factura PRIMARY KEY (id) INCLUDE (id);
 <   ALTER TABLE ONLY public.factura DROP CONSTRAINT pk_factura;
       public            postgres    false    215            m           2606    40983    cliente pk_idcliente 
   CONSTRAINT     _   ALTER TABLE ONLY public.cliente
    ADD CONSTRAINT pk_idcliente PRIMARY KEY (id) INCLUDE (id);
 >   ALTER TABLE ONLY public.cliente DROP CONSTRAINT pk_idcliente;
       public            postgres    false    214            o           2606    40985    cliente un_idcliente 
   CONSTRAINT     M   ALTER TABLE ONLY public.cliente
    ADD CONSTRAINT un_idcliente UNIQUE (id);
 >   ALTER TABLE ONLY public.cliente DROP CONSTRAINT un_idcliente;
       public            postgres    false    214            p           1259    40998    fki_fk_cliente    INDEX     H   CREATE INDEX fki_fk_cliente ON public.factura USING btree (id_cliente);
 "   DROP INDEX public.fki_fk_cliente;
       public            postgres    false    215            s           2606    40993    factura fk_cliente    FK CONSTRAINT     v   ALTER TABLE ONLY public.factura
    ADD CONSTRAINT fk_cliente FOREIGN KEY (id_cliente) REFERENCES public.cliente(id);
 <   ALTER TABLE ONLY public.factura DROP CONSTRAINT fk_cliente;
       public          postgres    false    214    3181    215               a   x�3�4�tK-�K�K��t�M,���I�434�47�TPP��8��(?�X!%5G��@���.3SδԢD�j��������\NKCs�4����� �z�            x������ � �     