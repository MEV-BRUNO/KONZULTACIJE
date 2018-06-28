CREATE DATABASE IF NOT EXISTS konzultacije_baza

CREATE TABLE IF NOT EXISTS Studij(
	id_studij INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	naziv VARCHAR(225)
);

CREATE TABLE IF NOT EXISTS Kolegij(
	id_kolegij INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	naziv VARCHAR(225),
	odabran BOOL
);



CREATE TABLE IF NOT EXISTS Profesor(
	id_profesor INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	ime_i_prezime VARCHAR(255),
	email VARCHAR(255),
	lozinka VARCHAR(255),
	aktivacijski_link VARCHAR(225),
	aktivan BOOL
);

CREATE TABLE IF NOT EXISTS Student(
	id_student INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	ime_i_prezime VARCHAR(225),
	id_studij INT,
	FOREIGN KEY(id_studij) REFERENCES Studij(id_studij),
	email VARCHAR(225),
	lozinka VARCHAR(225),
	aktivacijski_link VARCHAR(225),
	aktivan BOOL
);


CREATE TABLE IF NOT EXISTS Upit(
	id_upit INT PRIMARY KEY NOT NULL AUTO_INCREMENT,
	id_student INT,
	FOREIGN KEY(id_student) REFERENCES Student(id_student),
	id_profesor INT,
	FOREIGN KEY(id_profesor) REFERENCES Profesor(id_profesor),
	id_termina INT,
	FOREIGN KEY(id_termina) REFERENCES Termini(id_termina),
	naslov VARCHAR(225),
	opis VARCHAR(225),
	odgovoren BOOL
);


CREATE TABLE IF NOT EXISTS Termini(
	id_termina INT PRIMARY KEY AUTO_INCREMENT NOT NULL,
	id_profesor INT,
	FOREIGN KEY(id_profesor) REFERENCES Profesor(id_profesor),
	id_kolegij INT,
	FOREIGN KEY(id_kolegij) REFERENCES Kolegij(id_kolegij),
	dan_tjedan DATETIME NOT NULL,
	vrijeme_od TIME NOT NULL,
	vrijeme_do TIME NOT NULL
);

DROP TABLE kolegij_profesor
CREATE TABLE IF NOT EXISTS Kolegij_profesor(
	id_kolegij_profesor INT PRIMARY KEY NOT NULL AUTO_INCREMENT, 
	id_profesor INT,
	FOREIGN KEY(id_profesor) REFERENCES Profesor(id_profesor),
	id_kolegij INT,
	FOREIGN KEY(id_kolegij) REFERENCES Kolegij(id_kolegij)
);



INSERT INTO studij VALUES (NULL, 'Računarstvo');
INSERT INTO studij VALUES (NULL, 'Menadžment turizma i sporta');
INSERT INTO studij VALUES (NULL, 'Održivi razvoj');

SELECT * FROM studij

SELECT * FROM kolegij 

/* Popis predmeta za računarstvo*/
INSERT INTO kolegij VALUES (NULL, 'Engleski jezik 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tjelesna i zdrastvena kultura 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Matematika 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Ekonomika i organizacija poslovnih sustava', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Fizika', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove elektrotehnike i elektronike', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tjelesna i zdrastvena kultura 2', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Primjena računala', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Engleski jezik 2', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Matematika 2', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Programiranje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Digitalni elektronički skolopovi', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tjelesna i zdrastvena kultura 3', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Vještine komuniciranja', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Algoritmi i strukture podataka', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Vjerojatnost i statistika', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Arhitektura računala', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Objektno orijentirano programiranje 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tjelesna i zdrastvena kultura 4', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Programski alati u programiranju', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Baze podataka 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Računalne mreže', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Operacijski sustavi', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Izrada web sadržaja', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Multimedija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Uvod u informacijsku sigurnost', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Programsko inženjerstvo i informacijski sustavi', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Objektno orijentirano programiranje 2', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Seminar A', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Sigurnost računalnih umreženih sustava', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Administracija računalnih mreža', FALSE);
INSERT INTO kolegij VALUES (NULL, 'XML Programiranje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'PHP Programiranje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Baze podataka 2', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Digitalni marketing i oglašavanje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Menadžment', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Integracija računalnih sustava', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Razvoj mobilnih aplikacija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Razvoj računalnih igara', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Složeni aplikacijski programi', FALSE);


/*Popis predmeta za Menadžment turizma i sporta preddiplomski*/
INSERT INTO kolegij VALUES (NULL, 'Ekonomska matematika', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove ekonomije', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove trgovačkog prava', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Poslovni engleski jezik 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Poslovni njemački jezik 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Primjena računala u poslovnoj praksi', FALSE);

INSERT INTO kolegij VALUES (NULL, 'Mikroekonomija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Organizacija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove statistike', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Poduzetništvo', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Poslovni engleski jezik 2', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Poslovni njemački jezik 2', FALSE);

INSERT INTO kolegij VALUES (NULL, 'Makroekonomija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove Menadžmenta', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove računovodstva', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Porezni sustav', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Poslovne financije', FALSE);

INSERT INTO kolegij VALUES (NULL, 'Hotelski Menadžment', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Operativno planiranje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove marketinga', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove turizma', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Poslovno pregovaranje i komuniciranje', FALSE);

INSERT INTO kolegij VALUES (NULL, 'Animacija u turizmu', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Turistička geografija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Ekonomika turizma', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Pravo u turizmu', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Marketing u turizmu', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Sportski marketing', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Menadžment turizma i sporta', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Povijest sporta', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Uvod u sportsko pravo', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Turizam i kultura', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Medicina u turizmu i sportu', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Menadžment poslovne sigurnosti', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Poslovna etika', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Digitalni marketing i oglašavanje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Turizam i razvoj', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Istraživanje turističkog tržišta', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Specifični oblici turizma', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Menadžment sporta', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove kineziologije', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Sustavi natjecanja u sportu', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Strani jezik - engleski jezik', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Strani jezik - njemački jezik', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Informacijska pismenost', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Marketing turističkih i sportskih događaja', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Uvod u informacijsku sigurnost', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Organizacija javnih okupljanja', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Izrada web sadržaja', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove prava EU', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Razvoj inovativnih turističkih proizvoda', FALSE);






/*Popis predmeta za studij održivi razvoj*/
INSERT INTO kolegij VALUES (NULL, 'Matematika 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove energetike', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove računarstva', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Strani jezik 1 - engleski jezik', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Strani jezik 1 -  njemački jezik', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tehničko crtanje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tehnologija materijalnih resursa', FALSE);

INSERT INTO kolegij VALUES (NULL, 'Ekonomika i organizacija poslovanja', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Fizika', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Komunikologija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Konstrukcijsko crtanje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Matematika 2', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Primjenjena statistika', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Strani jezik 2 - engleksi jezik', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Strani jezik 2 - njemački jezik', FALSE);

INSERT INTO kolegij VALUES (NULL, 'Elektrotehnika', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Mehanika fluida', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tehnologija 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Upravljanje kvalitetom', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Termodinamika', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tehnološki software', FALSE);

INSERT INTO kolegij VALUES (NULL, 'Tehnologija 2', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Održavanje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Elektronički sklopovi', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove energetike i ekologije', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Energetske pretvorbe', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Osnove automatike', FALSE);

INSERT INTO kolegij VALUES (NULL, 'Grijanje i klimatizacija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Rashladna tehnika', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Vodovodne i plinske instalacije', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Pumpe, ventilatori i kompresori', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Mjerenje u termotehnici', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Ekološka održivost', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Upravljački software', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Oblikovanje pomoću računala', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tehnička dokumentacija i propisi', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Ekološka zaštita', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Upravljanje termotehničkim sustavom', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Toplinske mreže', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Održivost energije i samoodrživost', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Komunalno projektiranje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Industrijska sociologija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Statika i otpornost konstrukcije', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Arhitektonske konstrukcije i projektiranje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tehnologija građenja 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Ogranizacija građenja 1', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Mehanika graditeljstva', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Građevinske konstrukciej i projektiranje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Dimenzioniranje jednostavnih konstrukcija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Dimenzioniranje složenih konstrukcija', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Urbanističko planiranje i projektiranje', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Organizacija građenja 2', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Tehnologija građenja 2', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Održivost arhitekture', FALSE);
INSERT INTO kolegij VALUES (NULL, 'Ekologija', FALSE);

