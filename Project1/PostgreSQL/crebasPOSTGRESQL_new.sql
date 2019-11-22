/*==============================================================*/
/* DBMS name:      PostgreSQL 9.x                               */
/* Created on:     22.11.2019 9:28:51                           */
/*==============================================================*/

/*==============================================================*/
/* Table: Assessment_of_labor_expert                            */
/*==============================================================*/
create table Assessment_of_labor_expert (
   Id_assessment_of_labor_expert SERIAL               not null,
   Assessment           VARCHAR(10)          not null,
   constraint PK_ASSESSMENT_OF_LABOR_EXPERT primary key (Id_assessment_of_labor_expert)
);

/*==============================================================*/
/* Table: Card_accounting_preliminary_sci                       */
/*==============================================================*/
create table Card_accounting_preliminary_sci (
   Id_сard_accounting_preliminary_ SERIAL               not null,
   Date                 DATE                 not null,
   Applicant            VARCHAR(100)         not null,
   Short_description    VARCHAR(200)         not null,
   Result_preliminary_examination BOOL                 not null,
   Id_expertise         INT4                 not null,
   constraint PK_CARD_ACCOUNTING_PRELIMINARY primary key (Id_сard_accounting_preliminary_)
);

/*==============================================================*/
/* Table: Development_project                                   */
/*==============================================================*/
create table Development_project (
   Id_development_project SERIAL               not null,
   Id_legal_entity      INT4                 null,
   Id_individual_face   INT4                 null,
   Id_type_face         INT4                 not null,
   constraint PK_DEVELOPMENT_PROJECT primary key (Id_development_project)
);

/*==============================================================*/
/* Table: Direction_of_development_of_mil                       */
/*==============================================================*/
create table Direction_of_development_of_mil (
   Id_direction_of_development_of_ SERIAL               not null,
   Name_direction       VARCHAR(100)         not null,
   Id_field_of_development INT4                 not null,
   constraint PK_DIRECTION_OF_DEVELOPMENT_OF primary key (Id_direction_of_development_of_)
);

/*==============================================================*/
/* Table: FIO                                                   */
/*==============================================================*/
create table FIO (
   Id_fio               SERIAL               not null,
   First_name           VARCHAR(30)          not null,
   Second_name          VARCHAR(30)          not null,
   Surname              VARCHAR(30)          not null,
   constraint PK_FIO primary key (Id_fio)
);

/*==============================================================*/
/* Table: Field_of_development                                  */
/*==============================================================*/
create table Field_of_development (
   Id_field_of_development SERIAL               not null,
   Name_field_of_development VARCHAR(100)         not null,
   constraint PK_FIELD_OF_DEVELOPMENT primary key (Id_field_of_development)
);

/*==============================================================*/
/* Table: Hands_of_organizations                                */
/*==============================================================*/
create table Hands_of_organizations (
   Id_hand_of_organization SERIAL               not null,
   Surname              VARCHAR(30)          not null,
   Name                 VARCHAR(30)          not null,
   Second_name          VARCHAR(30)          not null,
   constraint PK_HANDS_OF_ORGANIZATIONS primary key (Id_hand_of_organization)
);

/*==============================================================*/
/* Table: Login_in                                              */
/*==============================================================*/
create table Login_in (
   Id_login_in          SERIAL               not null,
   Id_fio               INT8                 null,
   Login                VARCHAR(30)          not null,
   Access_level         VARCHAR(30)          not null,
   Password             VARCHAR(30)          not null,
   constraint PK_LOGIN_IN primary key (Id_login_in)
);

/*==============================================================*/
/* Table: Organization_affiliation                              */
/*==============================================================*/
create table Organization_affiliation (
   Id_organization_affiliation SERIAL               not null,
   Name_of_organization_affiliatio VARCHAR(50)          not null,
   constraint PK_ORGANIZATION_AFFILIATION primary key (Id_organization_affiliation)
);

/*==============================================================*/
/* Table: Place_of_project_source                               */
/*==============================================================*/
create table Place_of_project_source (
   Id_source_of_income_project SERIAL               not null,
   Type_of_sourse       VARCHAR(50)          not null,
   Name_of_sourse       VARCHAR(50)          not null,
   constraint PK_PLACE_OF_PROJECT_SOURCE primary key (Id_source_of_income_project)
);

/*==============================================================*/
/* Table: Possible_examination_results                          */
/*==============================================================*/
create table Possible_examination_results (
   Id_expert_result     SERIAL               not null,
   Name_expert_result   VARCHAR(50)          not null,
   constraint PK_POSSIBLE_EXAMINATION_RESULT primary key (Id_expert_result)
);

/*==============================================================*/
/* Table: Potential_content_organization                        */
/*==============================================================*/
create table Potential_content_organization (
   Id_of_potential_content_organiz SERIAL               not null,
   Name_of_potential_content_organ VARCHAR(100)         not null,
   constraint PK_POTENTIAL_CONTENT_ORGANIZAT primary key (Id_of_potential_content_organiz)
);

/*==============================================================*/
/* Table: Preliminary_examination_account                       */
/*==============================================================*/
create table Preliminary_examination_account (
   Id_expertise         SERIAL               not null,
   Project_codename     VARCHAR(30)          not null,
   Number_of_experts    INT4                 not null,
   Source_document_date DATE                 not null,
   Source_document_number VARCHAR(20)          not null,
   Type_of_organization BOOL                 not null,
   Name_of_company      VARCHAR(30)          not null,
   Id_expert            INT4                 not null,
   Date_outgoing_from_an_expert DATE                 not null,
   Incoming_document_date DATE                 not null,
   №_incoming_document  VARCHAR(20)          not null,
   Id_expert_result     INT4                 not null,
   Id_assessment_of_labor_expert INT4                 not null,
   Result               VARCHAR(100)         not null,
   Id_responsible_for_the_examinat INT4                 not null,
   Examination_report_date DATE                 not null,
   Outgoing_date        DATE                 not null,
   №_outgoing_date      VARCHAR(20)          not null,
   Notes                VARCHAR(200)         not null,
   constraint PK_PRELIMINARY_EXAMINATION_ACC primary key (Id_expertise)
);

/*==============================================================*/
/* Table: Preliminary_examination_stage                         */
/*==============================================================*/
create table Preliminary_examination_stage (
   Id_project           SERIAL               not null,
   Date_entered_project_in_databas DATE                 not null,
   Unic_identification_number VARCHAR(20)          not null,
   Id_type_of_project   INT4                 not null,
   Project_codename     VARCHAR(30)          not null,
   Denomination_of_project VARCHAR(100)         not null,
   Id_development_project INT4                 not null,
   Id_source_of_income_project INT4                 not null,
   Goals_and_objectives_of_the_pro VARCHAR(100)         not null,
   Id_direction_of_development_of_ INT4                 not null,
   Id_project_aviability INT4                 not null,
   Path_of_the_project_materials VARCHAR(100)         not null,
   Events_where_represented_the_pr VARCHAR(100)         not null,
   Id_unit_accompanying_the_projec INT4                 not null,
   Project_responsible  VARCHAR(100)         not null,
   Potential_consumers  VARCHAR(100)         not null,
   Result_preliminary_examination_ BOOL                 not null,
   Id_project_review_stage INT4                 null,
   constraint PK_PRELIMINARY_EXAMINATION_STA primary key (Id_project)
);

/*==============================================================*/
/* Table: Progress_of_scientific_and_tech                       */
/*==============================================================*/
create table Progress_of_scientific_and_tech (
   Id_progress_of_scientific_and_t SERIAL               not null,
   Name_of_progress_of_scientific_ VARCHAR(20)          not null,
   Id_result_of_scientific_and_tec INT4                 null,
   constraint PK_PROGRESS_OF_SCIENTIFIC_AND_ primary key (Id_progress_of_scientific_and_t)
);

/*==============================================================*/
/* Table: Project_aviability                                    */
/*==============================================================*/
create table Project_aviability (
   Id_project_aviability SERIAL               not null,
   Name_project_aviability VARCHAR(30)          not null,
   Id_type_project_stage INT4                 not null,
   constraint PK_PROJECT_AVIABILITY primary key (Id_project_aviability)
);

/*==============================================================*/
/* Table: Project_review_stage                                  */
/*==============================================================*/
create table Project_review_stage (
   Id_project_review_stage SERIAL               not null,
   Id_progress_of_scientific_and_t INT4                 not null,
   Path_of_the_examination_materia VARCHAR(100)         not null,
   Main_ways_of_project_implementa VARCHAR(200)         not null,
   Ability_to_use_in_the_civilian_ BOOL                 not null,
   Id_of_potential_content_organiz INT4                 null,
   Project_cost_or_price_for_the_f MONEY                null,
   File_of_priority_Action_Plan VARCHAR(200)         not null,
   File_of_development_criteria VARCHAR(200)         not null,
   constraint PK_PROJECT_REVIEW_STAGE primary key (Id_project_review_stage)
);

/*==============================================================*/
/* Table: Responsible_of_the_project                            */
/*==============================================================*/
create table Responsible_of_the_project (
   Id_responsible_for_the_examinat SERIAL               not null,
   Surname              VARCHAR(30)          not null,
   Name                 VARCHAR(30)          not null,
   Second_name          VARCHAR(30)          not null,
   constraint PK_RESPONSIBLE_OF_THE_PROJECT primary key (Id_responsible_for_the_examinat)
);

/*==============================================================*/
/* Table: Result_of_scientific_and_techni                       */
/*==============================================================*/
create table Result_of_scientific_and_techni (
   Id_result_of_scientific_and_tec SERIAL               not null,
   Name_of_result_of_scientific_an VARCHAR(20)          not null,
   constraint PK_RESULT_OF_SCIENTIFIC_AND_TE primary key (Id_result_of_scientific_and_tec)
);

/*==============================================================*/
/* Table: Roster_of_experts                                     */
/*==============================================================*/
create table Roster_of_experts (
   Id_expert            SERIAL               not null,
   Регион_местонахождения_эксперта VARCHAR(100)         not null,
   Id_организации_эксперта INT4                 not null,
   Surname              VARCHAR(30)          not null,
   Name                 VARCHAR(30)          not null,
   Second_name          VARCHAR(30)          not null,
   Academic_degree_of_expert VARCHAR(30)          not null,
   Academic_rank_of_expert VARCHAR(30)          not null,
   Id_admission_to_state_secret INT4                 not null,
   Address              VARCHAR(100)         not null,
   Phone                CHAR(12)             not null,
   Email_of_expert      VARCHAR(30)          not null,
   Specialization_of_expert_activi VARCHAR(30)          not null,
   Direction_of_scientific_activit VARCHAR(30)          not null,
   Expert_specialization VARCHAR(30)          not null,
   Basis_for_entry_in_the_register VARCHAR(20)          not null,
   File_with_examinations_conducte VARCHAR(100)         not null,
   Notes                VARCHAR(200)         null,
   constraint PK_ROSTER_OF_EXPERTS primary key (Id_expert)
);

/*==============================================================*/
/* Table: Roster_of_organizations_of_expe                       */
/*==============================================================*/
create table Roster_of_organizations_of_expe (
   Id_organization_of_expert SERIAL               not null,
   Id_organization_affiliation INT4                 not null,
   Id_type_of_organization INT4                 not null,
   Name_of_company      VARCHAR(100)         not null,
   Organization_mailing_address VARCHAR(100)         not null,
   E_mail_of_organization VARCHAR(30)          not null,
   Id_hand_of_organization INT4                 not null,
   constraint PK_ROSTER_OF_ORGANIZATIONS_OF_ primary key (Id_organization_of_expert)
);

/*==============================================================*/
/* Table: Table_of_individual_face                              */
/*==============================================================*/
create table Table_of_individual_face (
   Id_individual_face   SERIAL               not null,
   Plase_of_work        VARCHAR(100)         not null,
   Work_post            VARCHAR(100)         not null,
   Surname              VARCHAR(30)          not null,
   Name                 VARCHAR(30)          not null,
   Second_name          VARCHAR(30)          not null,
   Academic_degree      VARCHAR(30)          not null,
   Military_rank        VARCHAR(100)         not null,
   Address              VARCHAR(100)         not null,
   Phone                CHAR(12)             not null,
   E_mail               VARCHAR(30)          not null,
   constraint PK_TABLE_OF_INDIVIDUAL_FACE primary key (Id_individual_face)
);

/*==============================================================*/
/* Table: Table_of_ur_face                                      */
/*==============================================================*/
create table Table_of_ur_face (
   Id_legal_entity      SERIAL               not null,
   Id_individual_face   INT4                 not null,
   Form_of_incorporation VARCHAR(600)         not null,
   Address              VARCHAR(300)         not null,
   constraint PK_TABLE_OF_UR_FACE primary key (Id_legal_entity)
);

/*==============================================================*/
/* Table: Type_of_admission_to_state_secr                       */
/*==============================================================*/
create table Type_of_admission_to_state_secr (
   Id_admission_to_state_secret SERIAL               not null,
   Form_admission       VARCHAR(30)          not null,
   Document_number      VARCHAR(30)          not null,
   Date                 DATE                 not null,
   constraint PK_TYPE_OF_ADMISSION_TO_STATE_ primary key (Id_admission_to_state_secret)
);

/*==============================================================*/
/* Table: Type_of_organization                                  */
/*==============================================================*/
create table Type_of_organization (
   Id_type_of_organization SERIAL               not null,
   Name_type_of_organization VARCHAR(50)          not null,
   constraint PK_TYPE_OF_ORGANIZATION primary key (Id_type_of_organization)
);

/*==============================================================*/
/* Table: Type_project                                          */
/*==============================================================*/
create table Type_project (
   Id_type_of_project   SERIAL               not null,
   Name_type_project    VARCHAR(255)         not null,
   constraint PK_TYPE_PROJECT primary key (Id_type_of_project)
);

/*==============================================================*/
/* Table: Type_project_stage                                    */
/*==============================================================*/
create table Type_project_stage (
   Id_type_project_stage SERIAL               not null,
   Name_type_project_stage VARCHAR(30)          not null,
   constraint PK_TYPE_PROJECT_STAGE primary key (Id_type_project_stage)
);

/*==============================================================*/
/* Table: Unit_accompanying_the_project                         */
/*==============================================================*/
create table Unit_accompanying_the_project (
   Id_unit_accompanying_the_projec SERIAL               not null,
   Name_main_subdivision VARCHAR(20)          not null,
   Name_second_subdivision VARCHAR(30)          not null,
   constraint PK_UNIT_ACCOMPANYING_THE_PROJE primary key (Id_unit_accompanying_the_projec)
);

alter table Card_accounting_preliminary_sci
   add constraint Examination_is_underway foreign key (Id_expertise)
      references Preliminary_examination_account (Id_expertise);

alter table Development_project
   add constraint Development_individual_face foreign key (Id_individual_face)
      references Table_of_individual_face (Id_individual_face);

alter table Development_project
   add constraint Development_legal_entity foreign key (Id_legal_entity)
      references Table_of_ur_face (Id_legal_entity);

alter table Direction_of_development_of_mil
   add constraint Vector_join_area foreign key (Id_field_of_development)
      references Field_of_development (Id_field_of_development);

alter table Login_in
   add constraint Consists foreign key (Id_fio)
      references FIO (Id_fio)
      on delete restrict on update restrict;

alter table Preliminary_examination_account
   add constraint Conducts_examination foreign key (Id_expert)
      references Roster_of_experts (Id_expert);

alter table Preliminary_examination_account
   add constraint Rate foreign key (Id_expert_result)
      references Possible_examination_results (Id_expert_result);

alter table Preliminary_examination_account
   add constraint Responsible foreign key (Id_responsible_for_the_examinat)
      references Responsible_of_the_project (Id_responsible_for_the_examinat);

alter table Preliminary_examination_account
   add constraint Weighing foreign key (Id_assessment_of_labor_expert)
      references Assessment_of_labor_expert (Id_assessment_of_labor_expert);

alter table Preliminary_examination_stage
   add constraint Controlled_by foreign key (Id_unit_accompanying_the_projec)
      references Unit_accompanying_the_project (Id_unit_accompanying_the_projec);

alter table Preliminary_examination_stage
   add constraint Developer_was_doing_project foreign key (Id_development_project)
      references Development_project (Id_development_project);

alter table Preliminary_examination_stage
   add constraint Enter_the_unit foreign key (Id_direction_of_development_of_)
      references Direction_of_development_of_mil (Id_direction_of_development_of_);

alter table Preliminary_examination_stage
   add constraint Examination_stage_include_type_of_project foreign key (Id_type_of_project)
      references Type_project (Id_type_of_project);

alter table Preliminary_examination_stage
   add constraint Place_of_project_source_transfer_to_examination_stage foreign key (Id_source_of_income_project)
      references Place_of_project_source (Id_source_of_income_project);

alter table Preliminary_examination_stage
   add constraint Project_status foreign key (Id_project_aviability)
      references Project_aviability (Id_project_aviability);

alter table Preliminary_examination_stage
   add constraint Transposed foreign key (Id_project_review_stage)
      references Project_review_stage (Id_project_review_stage);

alter table Progress_of_scientific_and_tech
   add constraint Result foreign key (Id_result_of_scientific_and_tec)
      references Result_of_scientific_and_techni (Id_result_of_scientific_and_tec);

alter table Project_aviability
   add constraint Level_end_belongs_type_of_end foreign key (Id_type_project_stage)
      references Type_project_stage (Id_type_project_stage);

alter table Project_review_stage
   add constraint Content foreign key (Id_of_potential_content_organiz)
      references Potential_content_organization (Id_of_potential_content_organiz);

alter table Project_review_stage
   add constraint Held foreign key (Id_progress_of_scientific_and_t)
      references Progress_of_scientific_and_tech (Id_progress_of_scientific_and_t);

alter table Roster_of_experts
   add constraint Allowed foreign key (Id_admission_to_state_secret)
      references Type_of_admission_to_state_secr (Id_admission_to_state_secret);

alter table Roster_of_experts
   add constraint Works foreign key (Id_организации_эксперта)
      references Roster_of_organizations_of_expe (Id_organization_of_expert);

alter table Roster_of_organizations_of_expe
   add constraint Affiliation foreign key (Id_organization_affiliation)
      references Organization_affiliation (Id_organization_affiliation);

alter table Roster_of_organizations_of_expe
   add constraint Applies foreign key (Id_type_of_organization)
      references Type_of_organization (Id_type_of_organization);

alter table Roster_of_organizations_of_expe
   add constraint Lead foreign key (Id_hand_of_organization)
      references Hands_of_organizations (Id_hand_of_organization);

alter table Table_of_ur_face
   add constraint Works_in_legal_entity foreign key (Id_individual_face)
      references Table_of_individual_face (Id_individual_face);

