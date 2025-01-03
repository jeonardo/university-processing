PGDMP         (                 z            BNTU    13.3    13.3 �    �           0    0    ENCODING    ENCODING        SET client_encoding = 'UTF8';
                      false            �           0    0 
   STDSTRINGS 
   STDSTRINGS     (   SET standard_conforming_strings = 'on';
                      false            �           0    0 
   SEARCHPATH 
   SEARCHPATH     8   SELECT pg_catalog.set_config('search_path', '', false);
                      false            �           1262    16395    BNTU    DATABASE     c   CREATE DATABASE "BNTU" WITH TEMPLATE = template0 ENCODING = 'UTF8' LOCALE = 'Russian_Russia.1251';
    DROP DATABASE "BNTU";
                postgres    false            �            1259    16396    cathedra    TABLE     �   CREATE TABLE public.cathedra (
    cathedra_id integer NOT NULL,
    cathedra_name character varying(255) NOT NULL,
    fk_faculty integer NOT NULL,
    cathedra_name_full character varying(255)
);
    DROP TABLE public.cathedra;
       public         heap    postgres    false            �            1259    16399    cathedra_cathedra_id_seq    SEQUENCE     �   CREATE SEQUENCE public.cathedra_cathedra_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.cathedra_cathedra_id_seq;
       public          postgres    false    200            �           0    0    cathedra_cathedra_id_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.cathedra_cathedra_id_seq OWNED BY public.cathedra.cathedra_id;
          public          postgres    false    201            �            1259    16401    diplom_work    TABLE     �   CREATE TABLE public.diplom_work (
    id_diplom_work integer NOT NULL,
    name character varying(255) NOT NULL,
    id_status character varying,
    id_student integer,
    id_leader integer,
    mark character varying DEFAULT 0
);
    DROP TABLE public.diplom_work;
       public         heap    postgres    false            �            1259    16408    diplom_work_id_diplom_work_seq    SEQUENCE     �   CREATE SEQUENCE public.diplom_work_id_diplom_work_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public.diplom_work_id_diplom_work_seq;
       public          postgres    false    202            �           0    0    diplom_work_id_diplom_work_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public.diplom_work_id_diplom_work_seq OWNED BY public.diplom_work.id_diplom_work;
          public          postgres    false    203            �            1259    16410    faculty    TABLE     �   CREATE TABLE public.faculty (
    faculty_id integer NOT NULL,
    faculty_name character varying(255) NOT NULL,
    fk_university integer NOT NULL,
    faculty_name_full character varying(255) NOT NULL
);
    DROP TABLE public.faculty;
       public         heap    postgres    false            �            1259    16413    faculty_faculty_id_seq    SEQUENCE     �   CREATE SEQUENCE public.faculty_faculty_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 -   DROP SEQUENCE public.faculty_faculty_id_seq;
       public          postgres    false    204            �           0    0    faculty_faculty_id_seq    SEQUENCE OWNED BY     Q   ALTER SEQUENCE public.faculty_faculty_id_seq OWNED BY public.faculty.faculty_id;
          public          postgres    false    205            �            1259    16415    groups    TABLE     �   CREATE TABLE public.groups (
    group_id integer NOT NULL,
    group_name character varying(255) NOT NULL,
    fk_specialty integer NOT NULL
);
    DROP TABLE public.groups;
       public         heap    postgres    false            �            1259    16418    group_group_id_seq    SEQUENCE     �   CREATE SEQUENCE public.group_group_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 )   DROP SEQUENCE public.group_group_id_seq;
       public          postgres    false    206            �           0    0    group_group_id_seq    SEQUENCE OWNED BY     J   ALTER SEQUENCE public.group_group_id_seq OWNED BY public.groups.group_id;
          public          postgres    false    207            �            1259    49410    head_of_department    TABLE     �   CREATE TABLE public.head_of_department (
    head_id integer NOT NULL,
    user_id integer NOT NULL,
    cathedra_id integer NOT NULL
);
 &   DROP TABLE public.head_of_department;
       public         heap    postgres    false            �            1259    49408    head_of_department_head_id_seq    SEQUENCE     �   CREATE SEQUENCE public.head_of_department_head_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 5   DROP SEQUENCE public.head_of_department_head_id_seq;
       public          postgres    false    241            �           0    0    head_of_department_head_id_seq    SEQUENCE OWNED BY     a   ALTER SEQUENCE public.head_of_department_head_id_seq OWNED BY public.head_of_department.head_id;
          public          postgres    false    240            �            1259    16645    lectors    TABLE       CREATE TABLE public.lectors (
    lector_id integer NOT NULL,
    user_id integer NOT NULL,
    cathedra_id integer NOT NULL,
    vacancy integer DEFAULT 0 NOT NULL,
    busy_place integer DEFAULT 0 NOT NULL,
    "position" character varying(50) NOT NULL
);
    DROP TABLE public.lectors;
       public         heap    postgres    false            �            1259    24837    lectors_id_seq    SEQUENCE     w   CREATE SEQUENCE public.lectors_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.lectors_id_seq;
       public          postgres    false    238            �           0    0    lectors_id_seq    SEQUENCE OWNED BY     H   ALTER SEQUENCE public.lectors_id_seq OWNED BY public.lectors.lector_id;
          public          postgres    false    239            �            1259    16420 
   percentage    TABLE     �   CREATE TABLE public.percentage (
    id_percentage integer NOT NULL,
    comment character varying,
    name character varying,
    start_date character varying,
    end_date character varying,
    sec_id integer,
    plan_percent character varying
);
    DROP TABLE public.percentage;
       public         heap    postgres    false            �            1259    16426    percentage_id_percentage_seq    SEQUENCE     �   CREATE SEQUENCE public.percentage_id_percentage_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 3   DROP SEQUENCE public.percentage_id_percentage_seq;
       public          postgres    false    208            �           0    0    percentage_id_percentage_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public.percentage_id_percentage_seq OWNED BY public.percentage.id_percentage;
          public          postgres    false    209            �            1259    16428    roles    TABLE     k   CREATE TABLE public.roles (
    role_id integer NOT NULL,
    role_name character varying(255) NOT NULL
);
    DROP TABLE public.roles;
       public         heap    postgres    false            �            1259    65843    rolesExample    TABLE     v   CREATE TABLE public."rolesExample" (
    id integer NOT NULL,
    example integer,
    name character varying(255)
);
 "   DROP TABLE public."rolesExample";
       public         heap    postgres    false            �            1259    65841    rolesExample_id_seq    SEQUENCE     �   CREATE SEQUENCE public."rolesExample_id_seq"
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 ,   DROP SEQUENCE public."rolesExample_id_seq";
       public          postgres    false    245            �           0    0    rolesExample_id_seq    SEQUENCE OWNED BY     O   ALTER SEQUENCE public."rolesExample_id_seq" OWNED BY public."rolesExample".id;
          public          postgres    false    244            �            1259    16431    roles_role_id_seq    SEQUENCE     �   CREATE SEQUENCE public.roles_role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.roles_role_id_seq;
       public          postgres    false    210            �           0    0    roles_role_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.roles_role_id_seq OWNED BY public.roles.role_id;
          public          postgres    false    211            �            1259    16433    sec    TABLE       CREATE TABLE public.sec (
    sec_id integer NOT NULL,
    sec_number character varying,
    sec_start_date character varying,
    sec_end_date character varying,
    year_id integer,
    fk_cathedra integer,
    fk_group integer,
    fk_specialty integer
);
    DROP TABLE public.sec;
       public         heap    postgres    false            �            1259    16439 	   sec_event    TABLE     �   CREATE TABLE public.sec_event (
    id_sec_event integer NOT NULL,
    address character varying,
    date character varying,
    end_date character varying,
    sec_id integer,
    group_id integer
);
    DROP TABLE public.sec_event;
       public         heap    postgres    false            �            1259    16445    sec_event_id_sec_event_seq    SEQUENCE     �   CREATE SEQUENCE public.sec_event_id_sec_event_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public.sec_event_id_sec_event_seq;
       public          postgres    false    213            �           0    0    sec_event_id_sec_event_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.sec_event_id_sec_event_seq OWNED BY public.sec_event.id_sec_event;
          public          postgres    false    214            �            1259    16447 	   sec_group    TABLE     o   CREATE TABLE public.sec_group (
    sec_id integer,
    group_id integer,
    sec_group_id integer NOT NULL
);
    DROP TABLE public.sec_group;
       public         heap    postgres    false            �            1259    16450    sec_group_sec_group_id_seq    SEQUENCE     �   CREATE SEQUENCE public.sec_group_sec_group_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public.sec_group_sec_group_id_seq;
       public          postgres    false    215            �           0    0    sec_group_sec_group_id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.sec_group_sec_group_id_seq OWNED BY public.sec_group.sec_group_id;
          public          postgres    false    216            �            1259    16452    sec_role    TABLE     _   CREATE TABLE public.sec_role (
    id_sec_role integer NOT NULL,
    name character varying
);
    DROP TABLE public.sec_role;
       public         heap    postgres    false            �            1259    16458    sec_role_id_sec_role_seq    SEQUENCE     �   CREATE SEQUENCE public.sec_role_id_sec_role_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.sec_role_id_sec_role_seq;
       public          postgres    false    217            �           0    0    sec_role_id_sec_role_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.sec_role_id_sec_role_seq OWNED BY public.sec_role.id_sec_role;
          public          postgres    false    218            �            1259    16460    sec_sec_id_seq    SEQUENCE     �   CREATE SEQUENCE public.sec_sec_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 %   DROP SEQUENCE public.sec_sec_id_seq;
       public          postgres    false    212            �           0    0    sec_sec_id_seq    SEQUENCE OWNED BY     A   ALTER SEQUENCE public.sec_sec_id_seq OWNED BY public.sec.sec_id;
          public          postgres    false    219            �            1259    16462    sec_specialty    TABLE     {   CREATE TABLE public.sec_specialty (
    sec_specialty_id integer NOT NULL,
    sec_id integer,
    specialty_id integer
);
 !   DROP TABLE public.sec_specialty;
       public         heap    postgres    false            �            1259    16465 "   sec_specialty_sec_specialty_id_seq    SEQUENCE     �   CREATE SEQUENCE public.sec_specialty_sec_specialty_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 9   DROP SEQUENCE public.sec_specialty_sec_specialty_id_seq;
       public          postgres    false    220            �           0    0 "   sec_specialty_sec_specialty_id_seq    SEQUENCE OWNED BY     i   ALTER SEQUENCE public.sec_specialty_sec_specialty_id_seq OWNED BY public.sec_specialty.sec_specialty_id;
          public          postgres    false    221            �            1259    16467    sec_user    TABLE     �   CREATE TABLE public.sec_user (
    id_sec_user integer NOT NULL,
    firstname character varying,
    lastname character varying,
    middlename character varying,
    id_user integer,
    id_sec_role integer,
    id_sec integer
);
    DROP TABLE public.sec_user;
       public         heap    postgres    false            �            1259    16473    sec_user_id_sec_user_seq    SEQUENCE     �   CREATE SEQUENCE public.sec_user_id_sec_user_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.sec_user_id_sec_user_seq;
       public          postgres    false    222            �           0    0    sec_user_id_sec_user_seq    SEQUENCE OWNED BY     U   ALTER SEQUENCE public.sec_user_id_sec_user_seq OWNED BY public.sec_user.id_sec_user;
          public          postgres    false    223            �            1259    16475 	   specialty    TABLE     �   CREATE TABLE public.specialty (
    specialty_id integer NOT NULL,
    fk_cathedra integer NOT NULL,
    specialty_name character varying(255),
    specialty_name_full character varying(255),
    specialty_number character varying(255)
);
    DROP TABLE public.specialty;
       public         heap    postgres    false            �            1259    16630    specialty_specialty_id_seq    SEQUENCE     �   CREATE SEQUENCE public.specialty_specialty_id_seq
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    MAXVALUE 2147483647
    CACHE 1;
 1   DROP SEQUENCE public.specialty_specialty_id_seq;
       public          postgres    false    224            �           0    0    specialty_specialty_id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.specialty_specialty_id_seq OWNED BY public.specialty.specialty_id;
          public          postgres    false    237            �            1259    16478    status    TABLE     d   CREATE TABLE public.status (
    id_status integer NOT NULL,
    name character varying NOT NULL
);
    DROP TABLE public.status;
       public         heap    postgres    false            �            1259    49441    students    TABLE     �   CREATE TABLE public.students (
    student_id integer NOT NULL,
    user_id integer NOT NULL,
    group_id integer NOT NULL,
    sec_event_id integer,
    leader_id integer
);
    DROP TABLE public.students;
       public         heap    postgres    false            �            1259    16487    students_marks    TABLE     �   CREATE TABLE public.students_marks (
    percent_id integer,
    sec_event_id integer,
    percent_mark integer,
    sec_event_mark integer,
    group_id integer,
    student_id integer,
    marks_id integer NOT NULL
);
 "   DROP TABLE public.students_marks;
       public         heap    postgres    false            �            1259    16490    students_marks_marks_id_seq    SEQUENCE     �   CREATE SEQUENCE public.students_marks_marks_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 2   DROP SEQUENCE public.students_marks_marks_id_seq;
       public          postgres    false    226            �           0    0    students_marks_marks_id_seq    SEQUENCE OWNED BY     [   ALTER SEQUENCE public.students_marks_marks_id_seq OWNED BY public.students_marks.marks_id;
          public          postgres    false    227            �            1259    49439    students_student_id_seq1    SEQUENCE     �   CREATE SEQUENCE public.students_student_id_seq1
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 /   DROP SEQUENCE public.students_student_id_seq1;
       public          postgres    false    243            �           0    0    students_student_id_seq1    SEQUENCE OWNED BY     T   ALTER SEQUENCE public.students_student_id_seq1 OWNED BY public.students.student_id;
          public          postgres    false    242            �            1259    16494 
   university    TABLE     �   CREATE TABLE public.university (
    university_id integer NOT NULL,
    university_name character varying(255) NOT NULL,
    university_name_full character varying(255) NOT NULL
);
    DROP TABLE public.university;
       public         heap    postgres    false            �            1259    16497    university_university_id_seq    SEQUENCE     �   CREATE SEQUENCE public.university_university_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 3   DROP SEQUENCE public.university_university_id_seq;
       public          postgres    false    228            �           0    0    university_university_id_seq    SEQUENCE OWNED BY     ]   ALTER SEQUENCE public.university_university_id_seq OWNED BY public.university.university_id;
          public          postgres    false    229            �            1259    16499    users    TABLE     �  CREATE TABLE public.users (
    user_id integer NOT NULL,
    user_login character varying(255) NOT NULL,
    user_password character varying(255) NOT NULL,
    user_first_name character varying(255) NOT NULL,
    user_second_name character varying(255) NOT NULL,
    user_middle_name character varying(255) NOT NULL,
    user_confirm boolean DEFAULT false NOT NULL,
    role_id integer NOT NULL
);
    DROP TABLE public.users;
       public         heap    postgres    false            �            1259    16506    users_roles    TABLE     `   CREATE TABLE public.users_roles (
    user_id integer NOT NULL,
    role_id integer NOT NULL
);
    DROP TABLE public.users_roles;
       public         heap    postgres    false            �            1259    16509    users_roles_role_id_seq    SEQUENCE     �   CREATE SEQUENCE public.users_roles_role_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.users_roles_role_id_seq;
       public          postgres    false    231            �           0    0    users_roles_role_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.users_roles_role_id_seq OWNED BY public.users_roles.role_id;
          public          postgres    false    232            �            1259    16511    users_roles_user_id_seq    SEQUENCE     �   CREATE SEQUENCE public.users_roles_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 .   DROP SEQUENCE public.users_roles_user_id_seq;
       public          postgres    false    231            �           0    0    users_roles_user_id_seq    SEQUENCE OWNED BY     S   ALTER SEQUENCE public.users_roles_user_id_seq OWNED BY public.users_roles.user_id;
          public          postgres    false    233            �            1259    16513    users_user_id_seq    SEQUENCE     �   CREATE SEQUENCE public.users_user_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 (   DROP SEQUENCE public.users_user_id_seq;
       public          postgres    false    230            �           0    0    users_user_id_seq    SEQUENCE OWNED BY     G   ALTER SEQUENCE public.users_user_id_seq OWNED BY public.users.user_id;
          public          postgres    false    234            �            1259    16515    years_of_study    TABLE     �   CREATE TABLE public.years_of_study (
    year_id integer NOT NULL,
    year_start character varying(255),
    year_end character varying(255)
);
 "   DROP TABLE public.years_of_study;
       public         heap    postgres    false            �            1259    16521    years_of_study_year_id_seq    SEQUENCE     �   CREATE SEQUENCE public.years_of_study_year_id_seq
    AS integer
    START WITH 1
    INCREMENT BY 1
    NO MINVALUE
    NO MAXVALUE
    CACHE 1;
 1   DROP SEQUENCE public.years_of_study_year_id_seq;
       public          postgres    false    235            �           0    0    years_of_study_year_id_seq    SEQUENCE OWNED BY     Y   ALTER SEQUENCE public.years_of_study_year_id_seq OWNED BY public.years_of_study.year_id;
          public          postgres    false    236            �           2604    16523    cathedra cathedra_id    DEFAULT     |   ALTER TABLE ONLY public.cathedra ALTER COLUMN cathedra_id SET DEFAULT nextval('public.cathedra_cathedra_id_seq'::regclass);
 C   ALTER TABLE public.cathedra ALTER COLUMN cathedra_id DROP DEFAULT;
       public          postgres    false    201    200            �           2604    16524    diplom_work id_diplom_work    DEFAULT     �   ALTER TABLE ONLY public.diplom_work ALTER COLUMN id_diplom_work SET DEFAULT nextval('public.diplom_work_id_diplom_work_seq'::regclass);
 I   ALTER TABLE public.diplom_work ALTER COLUMN id_diplom_work DROP DEFAULT;
       public          postgres    false    203    202            �           2604    16525    faculty faculty_id    DEFAULT     x   ALTER TABLE ONLY public.faculty ALTER COLUMN faculty_id SET DEFAULT nextval('public.faculty_faculty_id_seq'::regclass);
 A   ALTER TABLE public.faculty ALTER COLUMN faculty_id DROP DEFAULT;
       public          postgres    false    205    204            �           2604    16526    groups group_id    DEFAULT     q   ALTER TABLE ONLY public.groups ALTER COLUMN group_id SET DEFAULT nextval('public.group_group_id_seq'::regclass);
 >   ALTER TABLE public.groups ALTER COLUMN group_id DROP DEFAULT;
       public          postgres    false    207    206            �           2604    49413    head_of_department head_id    DEFAULT     �   ALTER TABLE ONLY public.head_of_department ALTER COLUMN head_id SET DEFAULT nextval('public.head_of_department_head_id_seq'::regclass);
 I   ALTER TABLE public.head_of_department ALTER COLUMN head_id DROP DEFAULT;
       public          postgres    false    241    240    241            �           2604    24839    lectors lector_id    DEFAULT     o   ALTER TABLE ONLY public.lectors ALTER COLUMN lector_id SET DEFAULT nextval('public.lectors_id_seq'::regclass);
 @   ALTER TABLE public.lectors ALTER COLUMN lector_id DROP DEFAULT;
       public          postgres    false    239    238            �           2604    16527    percentage id_percentage    DEFAULT     �   ALTER TABLE ONLY public.percentage ALTER COLUMN id_percentage SET DEFAULT nextval('public.percentage_id_percentage_seq'::regclass);
 G   ALTER TABLE public.percentage ALTER COLUMN id_percentage DROP DEFAULT;
       public          postgres    false    209    208            �           2604    16528    roles role_id    DEFAULT     n   ALTER TABLE ONLY public.roles ALTER COLUMN role_id SET DEFAULT nextval('public.roles_role_id_seq'::regclass);
 <   ALTER TABLE public.roles ALTER COLUMN role_id DROP DEFAULT;
       public          postgres    false    211    210            �           2604    65846    rolesExample id    DEFAULT     v   ALTER TABLE ONLY public."rolesExample" ALTER COLUMN id SET DEFAULT nextval('public."rolesExample_id_seq"'::regclass);
 @   ALTER TABLE public."rolesExample" ALTER COLUMN id DROP DEFAULT;
       public          postgres    false    244    245    245            �           2604    16529 
   sec sec_id    DEFAULT     h   ALTER TABLE ONLY public.sec ALTER COLUMN sec_id SET DEFAULT nextval('public.sec_sec_id_seq'::regclass);
 9   ALTER TABLE public.sec ALTER COLUMN sec_id DROP DEFAULT;
       public          postgres    false    219    212            �           2604    16530    sec_event id_sec_event    DEFAULT     �   ALTER TABLE ONLY public.sec_event ALTER COLUMN id_sec_event SET DEFAULT nextval('public.sec_event_id_sec_event_seq'::regclass);
 E   ALTER TABLE public.sec_event ALTER COLUMN id_sec_event DROP DEFAULT;
       public          postgres    false    214    213            �           2604    16531    sec_group sec_group_id    DEFAULT     �   ALTER TABLE ONLY public.sec_group ALTER COLUMN sec_group_id SET DEFAULT nextval('public.sec_group_sec_group_id_seq'::regclass);
 E   ALTER TABLE public.sec_group ALTER COLUMN sec_group_id DROP DEFAULT;
       public          postgres    false    216    215            �           2604    16532    sec_role id_sec_role    DEFAULT     |   ALTER TABLE ONLY public.sec_role ALTER COLUMN id_sec_role SET DEFAULT nextval('public.sec_role_id_sec_role_seq'::regclass);
 C   ALTER TABLE public.sec_role ALTER COLUMN id_sec_role DROP DEFAULT;
       public          postgres    false    218    217            �           2604    16533    sec_specialty sec_specialty_id    DEFAULT     �   ALTER TABLE ONLY public.sec_specialty ALTER COLUMN sec_specialty_id SET DEFAULT nextval('public.sec_specialty_sec_specialty_id_seq'::regclass);
 M   ALTER TABLE public.sec_specialty ALTER COLUMN sec_specialty_id DROP DEFAULT;
       public          postgres    false    221    220            �           2604    16534    sec_user id_sec_user    DEFAULT     |   ALTER TABLE ONLY public.sec_user ALTER COLUMN id_sec_user SET DEFAULT nextval('public.sec_user_id_sec_user_seq'::regclass);
 C   ALTER TABLE public.sec_user ALTER COLUMN id_sec_user DROP DEFAULT;
       public          postgres    false    223    222            �           2604    16634    specialty specialty_id    DEFAULT     �   ALTER TABLE ONLY public.specialty ALTER COLUMN specialty_id SET DEFAULT nextval('public.specialty_specialty_id_seq'::regclass);
 E   ALTER TABLE public.specialty ALTER COLUMN specialty_id DROP DEFAULT;
       public          postgres    false    237    224            �           2604    49444    students student_id    DEFAULT     {   ALTER TABLE ONLY public.students ALTER COLUMN student_id SET DEFAULT nextval('public.students_student_id_seq1'::regclass);
 B   ALTER TABLE public.students ALTER COLUMN student_id DROP DEFAULT;
       public          postgres    false    242    243    243            �           2604    16536    students_marks marks_id    DEFAULT     �   ALTER TABLE ONLY public.students_marks ALTER COLUMN marks_id SET DEFAULT nextval('public.students_marks_marks_id_seq'::regclass);
 F   ALTER TABLE public.students_marks ALTER COLUMN marks_id DROP DEFAULT;
       public          postgres    false    227    226            �           2604    16537    university university_id    DEFAULT     �   ALTER TABLE ONLY public.university ALTER COLUMN university_id SET DEFAULT nextval('public.university_university_id_seq'::regclass);
 G   ALTER TABLE public.university ALTER COLUMN university_id DROP DEFAULT;
       public          postgres    false    229    228            �           2604    16538    users user_id    DEFAULT     n   ALTER TABLE ONLY public.users ALTER COLUMN user_id SET DEFAULT nextval('public.users_user_id_seq'::regclass);
 <   ALTER TABLE public.users ALTER COLUMN user_id DROP DEFAULT;
       public          postgres    false    234    230            �           2604    16539    users_roles user_id    DEFAULT     z   ALTER TABLE ONLY public.users_roles ALTER COLUMN user_id SET DEFAULT nextval('public.users_roles_user_id_seq'::regclass);
 B   ALTER TABLE public.users_roles ALTER COLUMN user_id DROP DEFAULT;
       public          postgres    false    233    231            �           2604    16540    users_roles role_id    DEFAULT     z   ALTER TABLE ONLY public.users_roles ALTER COLUMN role_id SET DEFAULT nextval('public.users_roles_role_id_seq'::regclass);
 B   ALTER TABLE public.users_roles ALTER COLUMN role_id DROP DEFAULT;
       public          postgres    false    232    231            �           2604    16541    years_of_study year_id    DEFAULT     �   ALTER TABLE ONLY public.years_of_study ALTER COLUMN year_id SET DEFAULT nextval('public.years_of_study_year_id_seq'::regclass);
 E   ALTER TABLE public.years_of_study ALTER COLUMN year_id DROP DEFAULT;
       public          postgres    false    236    235            �          0    16396    cathedra 
   TABLE DATA           ^   COPY public.cathedra (cathedra_id, cathedra_name, fk_faculty, cathedra_name_full) FROM stdin;
    public          postgres    false    200   �       �          0    16401    diplom_work 
   TABLE DATA           c   COPY public.diplom_work (id_diplom_work, name, id_status, id_student, id_leader, mark) FROM stdin;
    public          postgres    false    202   W�       �          0    16410    faculty 
   TABLE DATA           ]   COPY public.faculty (faculty_id, faculty_name, fk_university, faculty_name_full) FROM stdin;
    public          postgres    false    204   ��       �          0    16415    groups 
   TABLE DATA           D   COPY public.groups (group_id, group_name, fk_specialty) FROM stdin;
    public          postgres    false    206   �       �          0    49410    head_of_department 
   TABLE DATA           K   COPY public.head_of_department (head_id, user_id, cathedra_id) FROM stdin;
    public          postgres    false    241   s�       �          0    16645    lectors 
   TABLE DATA           c   COPY public.lectors (lector_id, user_id, cathedra_id, vacancy, busy_place, "position") FROM stdin;
    public          postgres    false    238   ��       �          0    16420 
   percentage 
   TABLE DATA           n   COPY public.percentage (id_percentage, comment, name, start_date, end_date, sec_id, plan_percent) FROM stdin;
    public          postgres    false    208   �       �          0    16428    roles 
   TABLE DATA           3   COPY public.roles (role_id, role_name) FROM stdin;
    public          postgres    false    210   ��       �          0    65843    rolesExample 
   TABLE DATA           ;   COPY public."rolesExample" (id, example, name) FROM stdin;
    public          postgres    false    245   M�       �          0    16433    sec 
   TABLE DATA           }   COPY public.sec (sec_id, sec_number, sec_start_date, sec_end_date, year_id, fk_cathedra, fk_group, fk_specialty) FROM stdin;
    public          postgres    false    212   ��       �          0    16439 	   sec_event 
   TABLE DATA           \   COPY public.sec_event (id_sec_event, address, date, end_date, sec_id, group_id) FROM stdin;
    public          postgres    false    213   �       �          0    16447 	   sec_group 
   TABLE DATA           C   COPY public.sec_group (sec_id, group_id, sec_group_id) FROM stdin;
    public          postgres    false    215   ��       �          0    16452    sec_role 
   TABLE DATA           5   COPY public.sec_role (id_sec_role, name) FROM stdin;
    public          postgres    false    217   �       �          0    16462    sec_specialty 
   TABLE DATA           O   COPY public.sec_specialty (sec_specialty_id, sec_id, specialty_id) FROM stdin;
    public          postgres    false    220   z�       �          0    16467    sec_user 
   TABLE DATA           n   COPY public.sec_user (id_sec_user, firstname, lastname, middlename, id_user, id_sec_role, id_sec) FROM stdin;
    public          postgres    false    222   ��       �          0    16475 	   specialty 
   TABLE DATA           u   COPY public.specialty (specialty_id, fk_cathedra, specialty_name, specialty_name_full, specialty_number) FROM stdin;
    public          postgres    false    224   7�       �          0    16478    status 
   TABLE DATA           1   COPY public.status (id_status, name) FROM stdin;
    public          postgres    false    225   ��       �          0    49441    students 
   TABLE DATA           Z   COPY public.students (student_id, user_id, group_id, sec_event_id, leader_id) FROM stdin;
    public          postgres    false    243   ��       �          0    16487    students_marks 
   TABLE DATA           �   COPY public.students_marks (percent_id, sec_event_id, percent_mark, sec_event_mark, group_id, student_id, marks_id) FROM stdin;
    public          postgres    false    226   ��       �          0    16494 
   university 
   TABLE DATA           Z   COPY public.university (university_id, university_name, university_name_full) FROM stdin;
    public          postgres    false    228   6�       �          0    16499    users 
   TABLE DATA           �   COPY public.users (user_id, user_login, user_password, user_first_name, user_second_name, user_middle_name, user_confirm, role_id) FROM stdin;
    public          postgres    false    230   ��       �          0    16506    users_roles 
   TABLE DATA           7   COPY public.users_roles (user_id, role_id) FROM stdin;
    public          postgres    false    231   o�       �          0    16515    years_of_study 
   TABLE DATA           G   COPY public.years_of_study (year_id, year_start, year_end) FROM stdin;
    public          postgres    false    235   ��       �           0    0    cathedra_cathedra_id_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.cathedra_cathedra_id_seq', 12, true);
          public          postgres    false    201            �           0    0    diplom_work_id_diplom_work_seq    SEQUENCE SET     M   SELECT pg_catalog.setval('public.diplom_work_id_diplom_work_seq', 15, true);
          public          postgres    false    203            �           0    0    faculty_faculty_id_seq    SEQUENCE SET     E   SELECT pg_catalog.setval('public.faculty_faculty_id_seq', 32, true);
          public          postgres    false    205            �           0    0    group_group_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.group_group_id_seq', 16, true);
          public          postgres    false    207            �           0    0    head_of_department_head_id_seq    SEQUENCE SET     L   SELECT pg_catalog.setval('public.head_of_department_head_id_seq', 2, true);
          public          postgres    false    240            �           0    0    lectors_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.lectors_id_seq', 10, true);
          public          postgres    false    239            �           0    0    percentage_id_percentage_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('public.percentage_id_percentage_seq', 27, true);
          public          postgres    false    209            �           0    0    rolesExample_id_seq    SEQUENCE SET     C   SELECT pg_catalog.setval('public."rolesExample_id_seq"', 4, true);
          public          postgres    false    244            �           0    0    roles_role_id_seq    SEQUENCE SET     ?   SELECT pg_catalog.setval('public.roles_role_id_seq', 4, true);
          public          postgres    false    211            �           0    0    sec_event_id_sec_event_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public.sec_event_id_sec_event_seq', 19, true);
          public          postgres    false    214            �           0    0    sec_group_sec_group_id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public.sec_group_sec_group_id_seq', 26, true);
          public          postgres    false    216            �           0    0    sec_role_id_sec_role_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.sec_role_id_sec_role_seq', 2, true);
          public          postgres    false    218            �           0    0    sec_sec_id_seq    SEQUENCE SET     =   SELECT pg_catalog.setval('public.sec_sec_id_seq', 25, true);
          public          postgres    false    219            �           0    0 "   sec_specialty_sec_specialty_id_seq    SEQUENCE SET     Q   SELECT pg_catalog.setval('public.sec_specialty_sec_specialty_id_seq', 52, true);
          public          postgres    false    221            �           0    0    sec_user_id_sec_user_seq    SEQUENCE SET     G   SELECT pg_catalog.setval('public.sec_user_id_sec_user_seq', 18, true);
          public          postgres    false    223            �           0    0    specialty_specialty_id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public.specialty_specialty_id_seq', 17, true);
          public          postgres    false    237            �           0    0    students_marks_marks_id_seq    SEQUENCE SET     J   SELECT pg_catalog.setval('public.students_marks_marks_id_seq', 29, true);
          public          postgres    false    227            �           0    0    students_student_id_seq1    SEQUENCE SET     F   SELECT pg_catalog.setval('public.students_student_id_seq1', 3, true);
          public          postgres    false    242            �           0    0    university_university_id_seq    SEQUENCE SET     K   SELECT pg_catalog.setval('public.university_university_id_seq', 21, true);
          public          postgres    false    229            �           0    0    users_roles_role_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.users_roles_role_id_seq', 1, false);
          public          postgres    false    232            �           0    0    users_roles_user_id_seq    SEQUENCE SET     F   SELECT pg_catalog.setval('public.users_roles_user_id_seq', 1, false);
          public          postgres    false    233                        0    0    users_user_id_seq    SEQUENCE SET     A   SELECT pg_catalog.setval('public.users_user_id_seq', 151, true);
          public          postgres    false    234                       0    0    years_of_study_year_id_seq    SEQUENCE SET     I   SELECT pg_catalog.setval('public.years_of_study_year_id_seq', 11, true);
          public          postgres    false    236            �           2606    16543    cathedra department_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public.cathedra
    ADD CONSTRAINT department_pkey PRIMARY KEY (cathedra_id);
 B   ALTER TABLE ONLY public.cathedra DROP CONSTRAINT department_pkey;
       public            postgres    false    200            �           2606    16545    diplom_work diplom_work_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.diplom_work
    ADD CONSTRAINT diplom_work_pkey PRIMARY KEY (id_diplom_work);
 F   ALTER TABLE ONLY public.diplom_work DROP CONSTRAINT diplom_work_pkey;
       public            postgres    false    202            �           2606    16547    faculty faculty_pkey 
   CONSTRAINT     Z   ALTER TABLE ONLY public.faculty
    ADD CONSTRAINT faculty_pkey PRIMARY KEY (faculty_id);
 >   ALTER TABLE ONLY public.faculty DROP CONSTRAINT faculty_pkey;
       public            postgres    false    204            �           2606    16549    groups group_pkey 
   CONSTRAINT     U   ALTER TABLE ONLY public.groups
    ADD CONSTRAINT group_pkey PRIMARY KEY (group_id);
 ;   ALTER TABLE ONLY public.groups DROP CONSTRAINT group_pkey;
       public            postgres    false    206            �           2606    49415 *   head_of_department head_of_department_pkey 
   CONSTRAINT     m   ALTER TABLE ONLY public.head_of_department
    ADD CONSTRAINT head_of_department_pkey PRIMARY KEY (head_id);
 T   ALTER TABLE ONLY public.head_of_department DROP CONSTRAINT head_of_department_pkey;
       public            postgres    false    241            �           2606    16649    lectors lectors_pkey 
   CONSTRAINT     Y   ALTER TABLE ONLY public.lectors
    ADD CONSTRAINT lectors_pkey PRIMARY KEY (lector_id);
 >   ALTER TABLE ONLY public.lectors DROP CONSTRAINT lectors_pkey;
       public            postgres    false    238            �           2606    16551    percentage percentage_pkey 
   CONSTRAINT     c   ALTER TABLE ONLY public.percentage
    ADD CONSTRAINT percentage_pkey PRIMARY KEY (id_percentage);
 D   ALTER TABLE ONLY public.percentage DROP CONSTRAINT percentage_pkey;
       public            postgres    false    208                       2606    65851    rolesExample rolesExample_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public."rolesExample"
    ADD CONSTRAINT "rolesExample_pkey" PRIMARY KEY (id);
 L   ALTER TABLE ONLY public."rolesExample" DROP CONSTRAINT "rolesExample_pkey";
       public            postgres    false    245            �           2606    16553    roles roles_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.roles
    ADD CONSTRAINT roles_pkey PRIMARY KEY (role_id);
 :   ALTER TABLE ONLY public.roles DROP CONSTRAINT roles_pkey;
       public            postgres    false    210            �           2606    16555    sec_event sec_event_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.sec_event
    ADD CONSTRAINT sec_event_pkey PRIMARY KEY (id_sec_event);
 B   ALTER TABLE ONLY public.sec_event DROP CONSTRAINT sec_event_pkey;
       public            postgres    false    213            �           2606    16557    sec_group sec_group_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.sec_group
    ADD CONSTRAINT sec_group_pkey PRIMARY KEY (sec_group_id);
 B   ALTER TABLE ONLY public.sec_group DROP CONSTRAINT sec_group_pkey;
       public            postgres    false    215            �           2606    16559    sec sec_pkey 
   CONSTRAINT     N   ALTER TABLE ONLY public.sec
    ADD CONSTRAINT sec_pkey PRIMARY KEY (sec_id);
 6   ALTER TABLE ONLY public.sec DROP CONSTRAINT sec_pkey;
       public            postgres    false    212            �           2606    16561    sec_role sec_role_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public.sec_role
    ADD CONSTRAINT sec_role_pkey PRIMARY KEY (id_sec_role);
 @   ALTER TABLE ONLY public.sec_role DROP CONSTRAINT sec_role_pkey;
       public            postgres    false    217            �           2606    16563     sec_specialty sec_specialty_pkey 
   CONSTRAINT     l   ALTER TABLE ONLY public.sec_specialty
    ADD CONSTRAINT sec_specialty_pkey PRIMARY KEY (sec_specialty_id);
 J   ALTER TABLE ONLY public.sec_specialty DROP CONSTRAINT sec_specialty_pkey;
       public            postgres    false    220            �           2606    16565    sec_user sec_user_pkey 
   CONSTRAINT     ]   ALTER TABLE ONLY public.sec_user
    ADD CONSTRAINT sec_user_pkey PRIMARY KEY (id_sec_user);
 @   ALTER TABLE ONLY public.sec_user DROP CONSTRAINT sec_user_pkey;
       public            postgres    false    222            �           2606    16567    specialty specialty_pkey 
   CONSTRAINT     `   ALTER TABLE ONLY public.specialty
    ADD CONSTRAINT specialty_pkey PRIMARY KEY (specialty_id);
 B   ALTER TABLE ONLY public.specialty DROP CONSTRAINT specialty_pkey;
       public            postgres    false    224            �           2606    16569    status status_pkey 
   CONSTRAINT     W   ALTER TABLE ONLY public.status
    ADD CONSTRAINT status_pkey PRIMARY KEY (id_status);
 <   ALTER TABLE ONLY public.status DROP CONSTRAINT status_pkey;
       public            postgres    false    225            �           2606    16571 "   students_marks students_marks_pkey 
   CONSTRAINT     f   ALTER TABLE ONLY public.students_marks
    ADD CONSTRAINT students_marks_pkey PRIMARY KEY (marks_id);
 L   ALTER TABLE ONLY public.students_marks DROP CONSTRAINT students_marks_pkey;
       public            postgres    false    226            �           2606    49446    students students_pkey 
   CONSTRAINT     \   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_pkey PRIMARY KEY (student_id);
 @   ALTER TABLE ONLY public.students DROP CONSTRAINT students_pkey;
       public            postgres    false    243            �           2606    16575    university university_pkey 
   CONSTRAINT     c   ALTER TABLE ONLY public.university
    ADD CONSTRAINT university_pkey PRIMARY KEY (university_id);
 D   ALTER TABLE ONLY public.university DROP CONSTRAINT university_pkey;
       public            postgres    false    228            �           2606    16577    users users_pkey 
   CONSTRAINT     S   ALTER TABLE ONLY public.users
    ADD CONSTRAINT users_pkey PRIMARY KEY (user_id);
 :   ALTER TABLE ONLY public.users DROP CONSTRAINT users_pkey;
       public            postgres    false    230            �           2606    16579    users_roles users_roles_pkey 
   CONSTRAINT     _   ALTER TABLE ONLY public.users_roles
    ADD CONSTRAINT users_roles_pkey PRIMARY KEY (user_id);
 F   ALTER TABLE ONLY public.users_roles DROP CONSTRAINT users_roles_pkey;
       public            postgres    false    231            �           2606    16581 "   years_of_study years_of_study_pkey 
   CONSTRAINT     e   ALTER TABLE ONLY public.years_of_study
    ADD CONSTRAINT years_of_study_pkey PRIMARY KEY (year_id);
 L   ALTER TABLE ONLY public.years_of_study DROP CONSTRAINT years_of_study_pkey;
       public            postgres    false    235            �           1259    16582    fki_fk_cathedra    INDEX     L   CREATE INDEX fki_fk_cathedra ON public.specialty USING btree (fk_cathedra);
 #   DROP INDEX public.fki_fk_cathedra;
       public            postgres    false    224            �           1259    16583    fki_fk_faculty    INDEX     I   CREATE INDEX fki_fk_faculty ON public.cathedra USING btree (fk_faculty);
 "   DROP INDEX public.fki_fk_faculty;
       public            postgres    false    200            �           1259    16584    fki_fk_group    INDEX     G   CREATE INDEX fki_fk_group ON public.groups USING btree (fk_specialty);
     DROP INDEX public.fki_fk_group;
       public            postgres    false    206            �           1259    16585    fki_fk_university    INDEX     N   CREATE INDEX fki_fk_university ON public.faculty USING btree (fk_university);
 %   DROP INDEX public.fki_fk_university;
       public            postgres    false    204                       2606    65852    cathedra cathedra_faculty_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.cathedra
    ADD CONSTRAINT cathedra_faculty_id FOREIGN KEY (fk_faculty) REFERENCES public.faculty(faculty_id) NOT VALID;
 F   ALTER TABLE ONLY public.cathedra DROP CONSTRAINT cathedra_faculty_id;
       public          postgres    false    200    3030    204                       2606    49463 &   diplom_work diplom_work_id_leader_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.diplom_work
    ADD CONSTRAINT diplom_work_id_leader_fkey FOREIGN KEY (id_leader) REFERENCES public.lectors(lector_id) NOT VALID;
 P   ALTER TABLE ONLY public.diplom_work DROP CONSTRAINT diplom_work_id_leader_fkey;
       public          postgres    false    238    3067    202                       2606    49458 '   diplom_work diplom_work_id_student_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.diplom_work
    ADD CONSTRAINT diplom_work_id_student_fkey FOREIGN KEY (id_student) REFERENCES public.students(student_id) NOT VALID;
 Q   ALTER TABLE ONLY public.diplom_work DROP CONSTRAINT diplom_work_id_student_fkey;
       public          postgres    false    202    3071    243                       2606    16635    specialty fk_cathedra    FK CONSTRAINT     �   ALTER TABLE ONLY public.specialty
    ADD CONSTRAINT fk_cathedra FOREIGN KEY (fk_cathedra) REFERENCES public.cathedra(cathedra_id) ON UPDATE CASCADE ON DELETE CASCADE;
 ?   ALTER TABLE ONLY public.specialty DROP CONSTRAINT fk_cathedra;
       public          postgres    false    200    224    3025                       2606    16596    groups fk_group    FK CONSTRAINT     �   ALTER TABLE ONLY public.groups
    ADD CONSTRAINT fk_group FOREIGN KEY (fk_specialty) REFERENCES public.specialty(specialty_id) NOT VALID;
 9   ALTER TABLE ONLY public.groups DROP CONSTRAINT fk_group;
       public          postgres    false    224    3053    206                       2606    16601    faculty fk_university    FK CONSTRAINT     �   ALTER TABLE ONLY public.faculty
    ADD CONSTRAINT fk_university FOREIGN KEY (fk_university) REFERENCES public.university(university_id) NOT VALID;
 ?   ALTER TABLE ONLY public.faculty DROP CONSTRAINT fk_university;
       public          postgres    false    204    228    3059                       2606    49421 (   head_of_department head_cathedra_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.head_of_department
    ADD CONSTRAINT head_cathedra_id_fkey FOREIGN KEY (cathedra_id) REFERENCES public.cathedra(cathedra_id) ON UPDATE RESTRICT ON DELETE RESTRICT;
 R   ALTER TABLE ONLY public.head_of_department DROP CONSTRAINT head_cathedra_id_fkey;
       public          postgres    false    200    3025    241                       2606    49416 $   head_of_department head_user_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.head_of_department
    ADD CONSTRAINT head_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON UPDATE CASCADE ON DELETE CASCADE;
 N   ALTER TABLE ONLY public.head_of_department DROP CONSTRAINT head_user_id_fkey;
       public          postgres    false    230    3061    241                       2606    16650     lectors lectors_cathedra_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.lectors
    ADD CONSTRAINT lectors_cathedra_id_fkey FOREIGN KEY (cathedra_id) REFERENCES public.cathedra(cathedra_id) ON UPDATE RESTRICT ON DELETE RESTRICT;
 J   ALTER TABLE ONLY public.lectors DROP CONSTRAINT lectors_cathedra_id_fkey;
       public          postgres    false    238    3025    200                       2606    24832    lectors lectors_user_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.lectors
    ADD CONSTRAINT lectors_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON UPDATE CASCADE ON DELETE CASCADE;
 F   ALTER TABLE ONLY public.lectors DROP CONSTRAINT lectors_user_id_fkey;
       public          postgres    false    230    238    3061                       2606    82261    percentage percentage_sec_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.percentage
    ADD CONSTRAINT percentage_sec_id FOREIGN KEY (sec_id) REFERENCES public.sec(sec_id) NOT VALID;
 F   ALTER TABLE ONLY public.percentage DROP CONSTRAINT percentage_sec_id;
       public          postgres    false    208    212    3040                       2606    16640    users roleId    FK CONSTRAINT     �   ALTER TABLE ONLY public.users
    ADD CONSTRAINT "roleId" FOREIGN KEY (role_id) REFERENCES public.roles(role_id) ON UPDATE RESTRICT ON DELETE RESTRICT;
 8   ALTER TABLE ONLY public.users DROP CONSTRAINT "roleId";
       public          postgres    false    210    230    3038                       2606    82251    sec_group sec-group_sec_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.sec_group
    ADD CONSTRAINT "sec-group_sec_id" FOREIGN KEY (sec_id) REFERENCES public.sec(sec_id) NOT VALID;
 F   ALTER TABLE ONLY public.sec_group DROP CONSTRAINT "sec-group_sec_id";
       public          postgres    false    212    3040    215            
           2606    74069    sec_event sec_event_sec_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.sec_event
    ADD CONSTRAINT sec_event_sec_id FOREIGN KEY (sec_id) REFERENCES public.sec(sec_id) NOT VALID;
 D   ALTER TABLE ONLY public.sec_event DROP CONSTRAINT sec_event_sec_id;
       public          postgres    false    3040    213    212                       2606    74044    sec sec_fk_cathedra    FK CONSTRAINT     �   ALTER TABLE ONLY public.sec
    ADD CONSTRAINT sec_fk_cathedra FOREIGN KEY (fk_cathedra) REFERENCES public.cathedra(cathedra_id) NOT VALID;
 =   ALTER TABLE ONLY public.sec DROP CONSTRAINT sec_fk_cathedra;
       public          postgres    false    200    3025    212                       2606    82246    sec_group sec_group_group_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.sec_group
    ADD CONSTRAINT sec_group_group_id FOREIGN KEY (group_id) REFERENCES public.groups(group_id) NOT VALID;
 F   ALTER TABLE ONLY public.sec_group DROP CONSTRAINT sec_group_group_id;
       public          postgres    false    206    215    3034                       2606    82236 "   sec_specialty sec_specilaty_sec_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.sec_specialty
    ADD CONSTRAINT sec_specilaty_sec_id FOREIGN KEY (sec_id) REFERENCES public.sec(sec_id) NOT VALID;
 L   ALTER TABLE ONLY public.sec_specialty DROP CONSTRAINT sec_specilaty_sec_id;
       public          postgres    false    212    220    3040                       2606    82241 (   sec_specialty sec_specilaty_specilaty_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.sec_specialty
    ADD CONSTRAINT sec_specilaty_specilaty_id FOREIGN KEY (specialty_id) REFERENCES public.specialty(specialty_id) NOT VALID;
 R   ALTER TABLE ONLY public.sec_specialty DROP CONSTRAINT sec_specilaty_specilaty_id;
       public          postgres    false    220    3053    224                       2606    74084    sec_user sec_user_id_sec    FK CONSTRAINT     �   ALTER TABLE ONLY public.sec_user
    ADD CONSTRAINT sec_user_id_sec FOREIGN KEY (id_sec) REFERENCES public.sec(sec_id) NOT VALID;
 B   ALTER TABLE ONLY public.sec_user DROP CONSTRAINT sec_user_id_sec;
       public          postgres    false    3040    212    222                       2606    74079    sec_user sec_user_id_sec_role    FK CONSTRAINT     �   ALTER TABLE ONLY public.sec_user
    ADD CONSTRAINT sec_user_id_sec_role FOREIGN KEY (id_sec_role) REFERENCES public.sec_role(id_sec_role) NOT VALID;
 G   ALTER TABLE ONLY public.sec_user DROP CONSTRAINT sec_user_id_sec_role;
       public          postgres    false    222    217    3046                       2606    74089    sec_user sec_user_id_user    FK CONSTRAINT     �   ALTER TABLE ONLY public.sec_user
    ADD CONSTRAINT sec_user_id_user FOREIGN KEY (id_user) REFERENCES public.users(user_id) NOT VALID;
 C   ALTER TABLE ONLY public.sec_user DROP CONSTRAINT sec_user_id_user;
       public          postgres    false    230    3061    222            	           2606    74074    sec sec_year_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.sec
    ADD CONSTRAINT sec_year_id FOREIGN KEY (year_id) REFERENCES public.years_of_study(year_id) NOT VALID;
 9   ALTER TABLE ONLY public.sec DROP CONSTRAINT sec_year_id;
       public          postgres    false    212    235    3065                       2606    49452    students students_group_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_group_id_fkey FOREIGN KEY (group_id) REFERENCES public.groups(group_id) NOT VALID;
 I   ALTER TABLE ONLY public.students DROP CONSTRAINT students_group_id_fkey;
       public          postgres    false    243    206    3034                       2606    57649     students students_leader_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_leader_id_fkey FOREIGN KEY (leader_id) REFERENCES public.lectors(lector_id) NOT VALID;
 J   ALTER TABLE ONLY public.students DROP CONSTRAINT students_leader_id_fkey;
       public          postgres    false    243    238    3067                       2606    82266 (   students_marks students_marks_percent_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.students_marks
    ADD CONSTRAINT students_marks_percent_id FOREIGN KEY (percent_id) REFERENCES public.percentage(id_percentage) NOT VALID;
 R   ALTER TABLE ONLY public.students_marks DROP CONSTRAINT students_marks_percent_id;
       public          postgres    false    3036    208    226                       2606    82271 *   students_marks students_marks_sec_event_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.students_marks
    ADD CONSTRAINT students_marks_sec_event_id FOREIGN KEY (sec_event_id) REFERENCES public.sec_event(id_sec_event) NOT VALID;
 T   ALTER TABLE ONLY public.students_marks DROP CONSTRAINT students_marks_sec_event_id;
       public          postgres    false    226    213    3042                       2606    82276 (   students_marks students_marks_student_id    FK CONSTRAINT     �   ALTER TABLE ONLY public.students_marks
    ADD CONSTRAINT students_marks_student_id FOREIGN KEY (student_id) REFERENCES public.students(student_id) NOT VALID;
 R   ALTER TABLE ONLY public.students_marks DROP CONSTRAINT students_marks_student_id;
       public          postgres    false    243    3071    226                       2606    49447    students students_user_id_fkey    FK CONSTRAINT     �   ALTER TABLE ONLY public.students
    ADD CONSTRAINT students_user_id_fkey FOREIGN KEY (user_id) REFERENCES public.users(user_id) ON UPDATE RESTRICT ON DELETE RESTRICT;
 H   ALTER TABLE ONLY public.students DROP CONSTRAINT students_user_id_fkey;
       public          postgres    false    230    3061    243            �   C  x�mQAN�P\����I���6n�Ȓ�	r8 ��I.pA*%FW$mR�-W�w#�}��4��3��f���903Ι��m(�Lj]GK�W,�2��Ա��$k��<�0!�2Q�X���3E��$���d�-�)2ҹ�9J�AEu�T&�?��8�:��\S]P�Mƾ�ZP�e4e❗ޤ���Ks5c�oo������p6���)N�֧����;?�og���g��T�n��`CPO�'@HB�C�d�rMU"�M5~��N��v2�����2����&�P�~_[V�/#�(2��^����t=�N���89�:�h�Oַm���_��:s      �   G  x��RAN�P]����P(յ	.]h\��3�@ Ut�	��h�@�>P����74�p�M�?��y����sy�w�J2,�{��0�'�d�av�m_s�s����������u/]�Q��A|�@��X���
铈�G���P>�+��*�I�USn��	�#�֯�ګ�YP	���x�<3�܂���J*,`cM��߉�"��c���(�f6s�z��&�:̷���l��g�O��Q��Uz�0ti�k������4�pW�Nm!N�[�l%��8�t���B2�wr6��A�2�=��J=����a3�o�p��j��'Q� ���      �   H  x���MN�0���)ru��t�aZ�$��U�%t�(!��
�7⍓P�MT��c{2��t��#�Lu� s���Y,��b�(\�H�5�V�ݹQ�}F�ȹ��ň���d�*}RdH�9R�����E$ފ�����T$� ��[9i�C�!��(vsr7��E�g��	��4v�T��Cã7�<|�"�QR^2�RG��e*�I��n�K�_�xфB9�+�c����,��?�����9Y���g:)��*�����&6���$mN�>�3���|�Ͻ�D��0��r_ko���՜ɜD�pw`�Y��%���eW���:�Z��f$�      �   ]   x�%ʻ�0C����%&`	J� $���cWG��B�a�o�I���,HP_�dp�̌s�LHT�ǚ9�c[��KO%L����dH����      �      x�3�446�4�2�441�4�����  ��      �   b   x�3�44��4�4�4༰�bӅ.v\�qa��.l���¾[�xP�	��}��˄��Ȍ���]�@]@=� ]S.����{��+F��� >I      �   �   x�]�AN1E�?���bg�	waI蚶�l��^�CT���J�WpnT�L
B���~��Dx|Z#o�)o���v�"�`��X����0"D�x�r�Z�$]P�br��z-u�a�-�;��9�w�廼�Y>�$���}K�r�^Gj���k�]�Y�j���F�WW[��Z� ���MǺ�����#�"�"#����",G&gVƘ+�]b@      �   G   x�3�LL����2�,NM.J-I,��2�,.)MI�+�2��HML��O�MI-H,*�	�p�&��q��qqq �/g      �   ?   x�3�41�LL����2�4616�LI,N)�2�411�L+OMKM�2�4425�t��LN����� qN�      �   Y   x�=��	� �ki��]c�&R�]�ҋ%�D��̰�$Z���֐}D��x�7�C�˽ڢ�TQ g��c*qz�n$w�c��9�      �   �   x�uл�0��<����d&�A"@"�	%55P��@��6�!������.�<Y�FT�� =e��r$�*�JC�Cm,�X��@Ҏn\Н+^I%�ٞtኮ��N\6���+��6_���D`�t�1�Y��;rܒ�7A��Y�l�}h=U�������tt��a�����?��3�\�-�;�w���n��P� ���      �   "   x�34�4�42�24�4�42ц�Ff\1z\\\ =��      �   R   x����0�x
&@�a�$5; *Z
"Y	0�y#��O�S�P-R,sY�M�����������N��w����������<1�      �       x�35�44�4�25ц\�F ڈ+F��� =��      �   }   x�]�A
!���a
?V�^��.gSh #x�&u
��>)x�/g�O����h�p��hF��Gu�޲�9眜}���vtP��tn��ZO����qb^�TaY���� h����D�4�      �   H  x��RAN�0<�_�#@����'���U#�� Z� '}A��M�0��nz��	�+��k��̮SId��৙dT>�f��(�8�'x�;�.P�af(�FѢ�`G_��P�W��O[���6<���a��KMy���K&����&,5��a�3w��g>ߛ;����|�'����:���i��J�+d�XsCQDu�A�v��}��T��d�����H�v\AH�B-Á8�uE-�ph�HR	�����*�+g�Mt����5�x��H�FKLM�+�;4�p�����ok��|S�' �~є�������������b��Ƙ_Q��t      �      x������ � �      �   +   x�3�445�4��".cNC#NC(ϐ����3����� ���      �   ?   x�32���C CcN#C.��73���sY�E�|sK�����%��S�f�F\1z\\\ 8�      �   �   x���=�@�k�)8���x[���-,�jallL�\��$�fn�,��hg��y��̼~��8#�@��1S&LP��=D��K��+���n��
.4�\I�L=�E(,�o��a��~�]��T*����~M��}�9͊EreiynUW��k����k��.d� �M� ��ظgfO���J      �   c  x���]��VƯ��c�8
z�ʨ���i� EPD���}i7M'��M�6m�M�^7vgMgv�ӯp�F=�:ݦ7���C��y���2�����X�����
��u�S8`)�����(uS
E�J�<����<_ih�C3�d)��{�!����)�ŗ�����L1������֘����v-��<�+*�A�e�F�@Y�y*�՜i���*lCݑG:n���l�a9PE��>Z�h�r+Jy]r��h8�z����Z%��9=�̐��[�E�{M)���;�'�!��?���5����
��/,C`�#�=��̆�|Z��}�ƺ8�4W�:ܮk��V�0�6&[=D����l����}�����~"�;�����g2|G&��.��\x�ڌ�%:�4�9�/X�6p��eY��pa�Z�ӆ�^��!J�����w�����/㯈�[�%���5���O����D���D�ϜT,^iV]�t�(]&�\e�FV֪ͪ�3Ls.�k&���(m��q�$�&�:~B�����-�O�y��t����<�Ɩ�YK�`�Jc|1�p���%C��5
��8�ݲ�ۣ�O�����o�ēj��a�o��'��0�����/��� ��Y�sg�����D#��R���zn[�Lz;Vܞa��A6"������$���b�P�7�)����=r�I $�,���Rd�C��FB;/+���m1,µ�o�8��Hj-g��"٢��l~M2&"~L�N$$�H��L�ϰ`�VI�n��,�G\�nu$��F�.�����*[j�N�[��&J
>�L��<�q	�!~_ů��H\���¯��{"�����D�gT*�����      �   =   x���  C�s�X@����R./?��}�e�Yn���d��O�"��/�����}W��      �   B   x�mʱ�@C��btv����s�#�ѽo96�A�����]���(���8�\M���Hz����Z�/     