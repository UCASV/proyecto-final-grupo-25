-- Proyecto Vacuna
-- Version 1.2

create database VacunaDB;
use VacunaDB;
SET LANGUAGE us_english;

create table cabina(
	id int primary key identity,
	direccion varchar(100) not null,
	telefono char(13) not null,
	email varchar(25) not null,
);

create table gestor(
	identificador int primary key,
	usuario varchar(20) not null,
	contrasena varchar(20) not null,
	nombre varchar(100) not null,
	email varchar(25) not null,
	direccion varchar(100) not null,
	id_tipo_empleado int not null,
	id_cabina_admin int
);

create table registro(
	id int primary key identity,
	id_cabina int not null,
	id_gestor int not null,
	fecha_hora datetime not null
);

create table tipo_empleado(
	id int primary key identity,
	tipo_empleado varchar(20) not null
);

create table vacuna(
	id int primary key identity,
	id_tipo_vacuna int not null,
	id_cabina int not null,
	id_gestor int not null,
	id_ciudadano int not null,
	cita_fecha_hora datetime,
	cola_fecha_hora datetime,
	vacuna_fecha_hora datetime
);

create table tipo_vacuna(
	id int primary key identity,
	tipo_vacuna varchar(20) not null
);

create table efecto_sec(
	id int primary key identity,
	efecto_sec varchar(100) not null,
);

create table registro_efecto(
	id int primary key identity,
	id_efecto_sec int not null,
	id_vacuna int not null,
	fecha_hora datetime
);

create table ciudadano(
	dui int primary key,
	nombre varchar(100) not null,
	fecha_nacimiento date not null,
	direccion varchar(100) not null,
	telefono varchar(13) not null,
	identificador_inst int,
	email varchar(25)
);

create table enfermedad(
	id int primary key identity,
	id_ciudadano int not null,
	enfermedad_cronica varchar(100) not null
);

-- Definiendo relaciones
alter table registro add foreign key (id_cabina) references cabina (id);
alter table registro add foreign key (id_gestor) references gestor (identificador);

alter table gestor add foreign key (id_tipo_empleado) references tipo_empleado (id);
alter table gestor add foreign key (id_cabina_admin) references cabina (id);

alter table vacuna add foreign key (id_tipo_vacuna) references tipo_vacuna (id);
alter table vacuna add foreign key (id_cabina) references cabina (id);
alter table vacuna add foreign key (id_gestor) references gestor (identificador);
alter table vacuna add foreign key (id_ciudadano) references ciudadano (dui);

alter table enfermedad add foreign key (id_ciudadano) references ciudadano (dui);

alter table registro_efecto add foreign key (id_vacuna) references vacuna (id);
alter table registro_efecto add foreign key (id_efecto_sec) references efecto_sec (id);

-- Banco de Datos
insert into tipo_vacuna values('Primera Dosis');
insert into tipo_vacuna values('Segunda Dosis');

insert into efecto_sec values ('Dolor y/o sensibilidad en el sitio de la inyección');
insert into efecto_sec values ('Enrojecimiento en el sitio de la inyección');
insert into efecto_sec values ('Fatiga');
insert into efecto_sec values ('Dolor de cabeza');
insert into efecto_sec values ('Fiebre');
insert into efecto_sec values ('Mialgia');
insert into efecto_sec values ('Artralgia');
insert into efecto_sec values ('Anafilaxia');

-- Ciudadanos
insert into ciudadano values(825534591,'Britanney','1945-12-10','Avenida Monseñor Romero y Final Calle 5 de Noviembre entre 21ª y 23ª Calle Oriente','2904-5600',1528,'QPLCOH@maiw.yom');
insert into ciudadano values(338102980,'Kameko','1953-11-8','Colonia Buenos Aires 3, Diagonal Centroamérica, Avenida Alvarado','2133-6912',4587,'UDZVYX@mail.tom');
insert into ciudadano values(176547228,'Damian Floyd','1948-12-21','1ª Calle Poniente entre 60ª Avenida Norte y Boulevard Constitución No. 3549','2287-6934',3254,'PVMNCC@maig.fom');
insert into ciudadano values(872125709,'Kristen','2000-11-4','Colonia San Francisco, Avenida Las Camelias y Calle Los Abetos No. 21','2504-4529',6016,'VIKSVJ@maik.kom');
insert into ciudadano values(136056655,'Kaseem Sears','1954-11-10','10ª Avenida Sur y Calle Lara No. 934, Barrio San Jacinto','2552-5135',6200,'PFQHXJ@maiq.rom');
insert into ciudadano values(266217677,'Susan','1960-5-5','Avenida Independencia y Alameda Juan Pablo II, No. 437','7250-8294',5882,null);
insert into ciudadano values(662232675,'Amena','1960-3-16','Edif. Torre Futura y Plaza Futura, Col. Escalón, SS.','2445-8874',null,'ZLUOLK@maij.pom');
insert into ciudadano values(300258992,'Aurelia Stanley','1963-5-31','Final Paseo General Escalón No. 5148, S. S','2652-9769',1372,'UOZWSE@maip.nom');
insert into ciudadano values(516828405,'Chloe','1947-7-25','Calle La Mascota Final Pje. A y Pje. No. 3, San Salvador','7263-2925',4951,'BAITLI@mair.nom');
insert into ciudadano values(748043393,'Glenna Frye','1982-6-28','Boulevard El Hipódromo y Avenida Las Magnolias, San Salvador','7726-2578',2965,'HWWWYS@maio.fom');
insert into ciudadano values(370257681,'Shaine','1970-4-5','Boulevard Constitución y 67 Av. Nte. No. 100, San Salvador','2553-1895',5178,'ASVGCM@maiv.vom');
insert into ciudadano values(816254427,'Basil Wilder','1974-7-25','C.Amberes y Alam. Manuel Enrique Araujo, Carr. a Sta.Tecla','2711-9001',6743,'XUQZUC@maii.rom');
insert into ciudadano values(607360502,'Natalie','1952-3-9','43 Avenida Norte y Alameda Franklin Delano Roosevelt No. 2222, San Salvador','7542-1175',3828,'RBGXGX@maih.xom');
insert into ciudadano values(502865382,'Evelyn Spears','1985-1-11','1a.Av.Norte y Calle Gerardo Barrios','2761-3648',3358,'YNYZKR@maip.pom');
insert into ciudadano values(421709020,'Jelani West','1972-9-4','Av.Napoleon Flores Hueso y calle grimaldi,Usulutàn','2887-8167',6638,'HRHTMP@maib.mom');
insert into ciudadano values(779006787,'Yvonne','1991-2-8',' 2a. Av. Sur y 2a. Calle Oriente','7975-9700',6979,'FLPNSR@maiw.lom');
insert into ciudadano values(313066165,'Patricia','1953-10-28','3a.Av. Sur No.13, Barrio El Centro','2583-3558',4307,'QVLRLB@maio.nom');
insert into ciudadano values(575801661,'Hayley Joseph','1960-12-23','Final Diagonal Universitaria No.1030, Col. Layco','2208-6297',2835,'EMUPNO@main.gom');
insert into ciudadano values(362571028,'Sara','1977-1-24','Av.Narciso Monterrey No. 7','7639-9241',null,'UQSSWQ@maix.som');
insert into ciudadano values(315221587,'Alexandra','1948-2-3','Calle Monseñor Romero No.5','2538-7699',6061,'BCHNCP@maic.kom');
insert into ciudadano values(423469497,'Serina Lopez','1987-10-23','Calle Bernardo Perdomo No.9','2559-2265',8853,'AZCABO@maio.zom');
insert into ciudadano values(545053214,'Lillian Stark','1956-5-24','Paseo General Escalón No 4640','7406-3222',5887,'IIOOHB@maia.jom');
insert into ciudadano values(207501366,'Tallulah','1984-6-27','Avenida Morazán No. 6 y 8 San Martín','7228-8332',null,'OWHCJQ@maic.som');
insert into ciudadano values(536330259,'Wendy','1992-5-22','Boulevard Los Próceres y Avenida La Ceiba Col. La Sultana','2657-4956',4171,'CDDSMN@maip.tom');
insert into ciudadano values(329275768,'Quyn','1971-1-16','Av. Independencia Sur y 35a. Calle Poniente, Santa Ana','2749-6431',8434,null);

insert into tipo_empleado values ('Enfermero/a');
insert into tipo_empleado values ('Doctor/a');
insert into tipo_empleado values ('Tecnico  IT');
insert into tipo_empleado values ('Admin');

insert into cabina values ('Paseo General Escalón No 4640', '2559-2265', 'BCHNCP@maic.kom');
insert into cabina values ('Calle La Mascota Final Pje. A y Pje. No. 3, San Salvador', '2538-7699', 'UDZVYX@mail.tom');
insert into cabina values ('3a.Av. Sur No.13, Barrio El Centro', '2652-9769', 'PVMNCC@maig.fom');
insert into cabina values ('Calle Monseñor Romero No.4', '2257-7777', 'YNYZKR@maip.pom');
insert into cabina values ('Boulevard Los Próceres y Avenida La Ceiba Col. La Sultana', '2583-3558', 'FLPNSR@maiw.lom');

insert into gestor values (86001, 'LSmith', 'asdf', 'Liam Smith', 'LSmith@gmail.com', 'Av. Independencia Sur y 35a. Calle Poniente, Santa Ana', 3, 1);
insert into gestor values (86002, 'EJones', 'qwer', 'Emma Jones', 'EJones@gmail.com', 'Boulevard Los Próceres y Avenida La Ceiba Col. La Sultana', 4, 2);
insert into gestor values (86003, 'LLopez', '1234', 'Luna Lopez', 'LLopez@gmail.com', 'Paseo General Escalón No 4640', 3, 3);
insert into gestor values (86004, 'MGarcia', 'abcd', 'Mila Garcia', 'MGarcia@gmail.com', 'Calle Bernardo Perdomo No.9', 4, 4);
insert into gestor values (86005, 'LBrown', '1010', 'Lucas Brown', 'LBrwon@gmail.com', 'Calle Monseñor Romero No.22', 2, 5);
insert into gestor values (86006, 'NPerez', 'hola', 'Nora Perez', 'Nperez@gmail.com', 'Av.Narciso Monterrey No. 7', 1, null);
insert into gestor values (86007, 'JLewis', '3434', 'Julian Lewis', 'JLewis@gmail.com', 'Calle Monseñor Romero No.25', 1, null);
insert into gestor values (86008, 'LSanchez', 'luke', 'Luke Sanchez', 'LSanchez@gmail.com', 'Calle Monseñor Romero No.57', 2, null);
insert into gestor values (86009, 'LDicaprio', 'qwerty', 'Leo Dicaprio', 'LDicaprio@gmail.com', 'Final Diagonal Universitaria No.1030, Col. Layco', 2, null);

insert into enfermedad values (136056655, 'Tension Arterial Alta');
insert into enfermedad values (176547228, 'Tension Arterial Alta');
insert into enfermedad values (266217677, 'Tension Arterial Alta');
insert into enfermedad values (300258992, 'Tension Arterial Alta');
insert into enfermedad values (313066165, 'Diabetes');
insert into enfermedad values (315221587, 'Diabetes');
insert into enfermedad values (329275768, 'Diabetes');
insert into enfermedad values (338102980, 'Diabetes');
insert into enfermedad values (370257681, 'Cardiopatia');
insert into enfermedad values (421709020, 'Cardiopatia');
insert into enfermedad values (423469497, 'Cardiopatia');
insert into enfermedad values (502865382, 'Cardiopatia');
insert into enfermedad values (516828405, 'Cardiopatia');
insert into enfermedad values (536330259, 'Accidente Cerebrovascular');
insert into enfermedad values (545053214, 'Accidente Cerebrovascular');
insert into enfermedad values (575801661, 'Accidente Cerebrovascular');
insert into enfermedad values (607360502, 'Accidente Cerebrovascular');
insert into enfermedad values (748043393, 'Afeccion Respiratoria');
insert into enfermedad values (779006787, 'Afeccion Respiratoria');
insert into enfermedad values (816254427, 'Afeccion Respiratoria');
insert into enfermedad values (825534591, 'Afeccion Respiratoria');
insert into enfermedad values (872125709, 'Afeccion Respiratoria');

-- Registros de gestores
insert into registro values (1, 86001, '2021-06-1 07:31:25.124');
insert into registro values (1, 86001, '2021-06-2 07:32:25.124');
insert into registro values (1, 86001, '2021-06-3 07:31:35.124');
insert into registro values (1, 86001, '2021-06-4 07:30:25.124');
insert into registro values (1, 86001, '2021-06-5 07:31:25.124');
insert into registro values (2, 86002, '2021-06-1 07:33:25.124');
insert into registro values (2, 86002, '2021-06-2 07:28:25.124');
insert into registro values (2, 86002, '2021-06-3 07:31:29.124');
insert into registro values (2, 86002, '2021-06-4 07:31:27.124');
insert into registro values (2, 86002, '2021-06-5 07:31:55.124');
insert into registro values (3, 86004, '2021-06-1 07:32:27.124');
insert into registro values (3, 86004, '2021-06-2 07:42:25.124');
insert into registro values (3, 86004, '2021-06-3 07:40:25.124');
insert into registro values (3, 86004, '2021-06-4 07:39:25.124');
insert into registro values (3, 86004, '2021-06-5 07:38:25.124');
insert into registro values (4, 86004, '2021-06-1 07:37:25.124');
insert into registro values (4, 86004, '2021-06-2 07:36:25.124');
insert into registro values (4, 86004, '2021-06-3 07:35:25.124');
insert into registro values (4, 86004, '2021-06-4 07:34:25.124');
insert into registro values (4, 86004, '2021-06-5 08:31:25.124');
insert into registro values (5, 86005, '2021-06-1 07:28:25.124');
insert into registro values (5, 86005, '2021-06-2 07:26:25.124');
insert into registro values (5, 86005, '2021-06-3 07:21:25.124');
insert into registro values (5, 86005, '2021-06-4 07:20:25.124');
insert into registro values (5, 86005, '2021-06-5 07:35:55.124');
insert into registro values (5, 86005, '2021-06-6 07:35');

-- Primeras dosis
insert into vacuna values (1, 1, 86001, 136056655, '2021-06-1 10:00', '2021-06-1 10:16', '2021-06-1 10:23');
insert into vacuna values (1, 1, 86001, 176547228, '2021-06-1 10:15', '2021-06-1 10:18', '2021-06-1 10:25');
insert into vacuna values (1, 1, 86001, 266217677, '2021-06-1 10:30', '2021-06-1 10:33', '2021-06-1 10:35');
insert into vacuna values (1, 1, 86001, 300258992, '2021-06-1 10:45', '2021-06-1 10:48', '2021-06-1 10:52');
insert into vacuna values (1, 1, 86001, 313066165, '2021-06-1 11:00', '2021-06-1 11:11', '2021-06-1 11:23');

insert into vacuna values (1, 2, 86002, 315221587, '2021-06-1 10:00', '2021-06-1 10:02', '2021-06-1 10:12');
insert into vacuna values (1, 2, 86002, 329275768, '2021-06-1 10:15', '2021-06-1 10:24', '2021-06-1 10:29');
insert into vacuna values (1, 2, 86002, 338102980, '2021-06-1 10:30', '2021-06-1 10:31', '2021-06-1 10:35');
insert into vacuna values (1, 2, 86002, 370257681, '2021-06-1 10:45', '2021-06-1 10:44', '2021-06-1 10:50');
insert into vacuna values (1, 2, 86002, 421709020, '2021-06-1 11:00', '2021-06-1 11:03', '2021-06-1 11:07');

insert into vacuna values (1, 3, 86003, 423469497, '2021-06-1 10:00', '2021-06-1 10:04', '2021-06-1 10:06');
insert into vacuna values (1, 3, 86003, 502865382, '2021-06-1 10:15', '2021-06-1 10:19', '2021-06-1 10:29');
insert into vacuna values (1, 3, 86003, 516828405, '2021-06-1 10:30', '2021-06-1 10:32', '2021-06-1 10:34');
insert into vacuna values (1, 3, 86003, 536330259, '2021-06-1 10:45', '2021-06-1 10:49', '2021-06-1 10:55');
insert into vacuna values (1, 3, 86003, 545053214, '2021-06-1 11:00', '2021-06-1 11:04', '2021-06-1 11:12');

insert into vacuna values (1, 4, 86004, 575801661, '2021-06-1 10:00', '2021-06-1 10:05', '2021-06-1 10:10');
insert into vacuna values (1, 4, 86004, 607360502, '2021-06-1 10:15', '2021-06-1 10:21', '2021-06-1 10:23');
insert into vacuna values (1, 4, 86004, 748043393, '2021-06-1 10:30', '2021-06-1 10:35', '2021-06-1 10:38');
insert into vacuna values (1, 4, 86004, 779006787, '2021-06-1 10:45', '2021-06-1 10:46', '2021-06-1 10:56');
insert into vacuna values (1, 4, 86004, 816254427, '2021-06-1 11:00', '2021-06-1 11:03', '2021-06-1 11:07');

insert into vacuna values (1, 5, 86005, 825534591, '2021-06-1 10:00', '2021-06-1 10:02', '2021-06-1 10:09');
insert into vacuna values (1, 5, 86005, 872125709, '2021-06-1 10:15', '2021-06-1 10:19', '2021-06-1 10:23');

--Segundas dosis
insert into vacuna values (2, 1, 86001, 136056655, '2021-06-9 08:00', '2021-06-9 08:16', '2021-06-9 08:23');
insert into vacuna values (2, 1, 86001, 176547228, '2021-06-9 08:15', '2021-06-9 08:18', '2021-06-9 08:25');
insert into vacuna values (2, 1, 86001, 266217677, '2021-06-9 08:30', '2021-06-9 08:33', '2021-06-9 08:34');
															  
insert into vacuna values (2, 2, 86002, 315221587, '2021-06-9 08:00', '2021-06-9 08:02', '2021-06-9 08:12');
insert into vacuna values (2, 2, 86002, 329275768, '2021-06-9 08:15', '2021-06-9 08:24', '2021-06-9 08:25');
insert into vacuna values (2, 2, 86002, 338102980, '2021-06-9 08:30', '2021-06-9 08:31', '2021-06-9 08:35');
															  
insert into vacuna values (2, 3, 86003, 423469497, '2021-06-9 08:00', '2021-06-9 08:04', '2021-06-9 08:06');
insert into vacuna values (2, 3, 86003, 502865382, '2021-06-9 08:15', '2021-06-9 08:16', '2021-06-9 08:27');
insert into vacuna values (2, 3, 86003, 516828405, '2021-06-9 08:30', '2021-06-9 08:32', '2021-06-9 08:34');
insert into vacuna values (2, 3, 86003, 536330259, '2021-06-9 08:45', '2021-06-9 08:45', '2021-06-9 08:55');
															  
insert into vacuna values (2, 4, 86004, 575801661, '2021-06-9 08:00', '2021-06-9 08:05', '2021-06-9 08:10');
insert into vacuna values (2, 4, 86004, 607360502, '2021-06-9 08:15', '2021-06-9 08:21', '2021-06-9 08:23');
insert into vacuna values (2, 4, 86004, 748043393, '2021-06-9 08:30', '2021-06-9 08:36', '2021-06-9 08:38');
															  
insert into vacuna values (2, 5, 86005, 825534591, '2021-06-9 08:00', '2021-06-9 08:05', '2021-06-9 08:09');
insert into vacuna values (2, 5, 86005, 872125709, '2021-06-9 08:15', '2021-06-9 08:20', '2021-06-9 08:23');

--Registro de efectos Secundarios
insert into registro_efecto values (4, 16, '2021-06-1 10:17');
insert into registro_efecto values (3, 22, '2021-06-1 10:25');
insert into registro_efecto values (2, 31, '2021-06-9 08:39');
insert into registro_efecto values (5, 35, '2021-06-9 08:45');

--Actualizando valores para tener todas las condiciones
update vacuna set vacuna_fecha_hora = null where id = 10;
update vacuna set cola_fecha_hora = null where id = 10;

update vacuna set vacuna_fecha_hora = null where id = 26;
update vacuna set cola_fecha_hora = null where id = 26;
