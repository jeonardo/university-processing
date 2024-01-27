import {Component, Inject, OnInit, TemplateRef, ViewChild} from '@angular/core';
import {AdminService} from '../../../services/admin/admin.service';
import {HeadOfDepartmentService} from '../../../services/headOfDepartment/head-of-department.service';
import { AuthService } from 'src/app/services/auth/auth.service';
import { Router } from '@angular/router';
import {NgbModal} from '@ng-bootstrap/ng-bootstrap';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA, MatDialogConfig} from '@angular/material/dialog';

import { Specialty1Model } from '../../../models/specialty1.model';
import {Group} from "../../../models/group.model";
import {RestService} from "../../../services/rest.service";
import {UserService} from "../../../services/user/user.service";
import {DiplomWorkService} from "../../../services/diplomWork/diplom-work.service";
import {GroupService} from "../../../services/university-structure/group/group.service";
import {MatTableDataSource} from "@angular/material/table";
import {SpecialtyService} from "../../../services/university-structure/specialty/specialty.service";
import {SpecialtyComponent} from "../../dialog/specialty/specialty.component";
import {GroupComponent} from "../../dialog/group/group.component";
import {LectorService} from "../../../services/lector/lector.service";
import {LectorsComponent} from "../../dialog/lectors/lectors.component";
import {StudentsListComponent} from "../../dialog/students-list/students-list.component";
import {SecService} from "../../../services/sec-structure/sec/sec.service";
import {SecComponent} from "../../dialog/sec/sec.component";
import {SecUserService} from "../../../services/sec-structure/sec-user/sec-user.service";
import {SecUserComponent} from "../../dialog/sec-user/sec-user.component";
import {userInfo} from "os";


@Component({
  selector: 'app-head-of-department',
  templateUrl: './head-of-department.component.html',
  styleUrls: ['./head-of-department.component.scss'],
})
export class HeadOfDepartmentComponent implements OnInit {
  specialtyColumns: string[] = ['specialtyFullName', 'specialtyName', 'code','action'];
  specialties: any;

  groupColumns: string[] = ['specialtyName', 'groupName', 'action'];
  groups: any;

  lectorsColumns: string[] = ['lectorName', 'position', 'allPlace', 'busyPlace','action'];
  lectors: any;

  secColumns: string[] = ['secNumber', 'dateStart', 'dateEnd', 'action'];
  sec: any;

  isEditSecOpen: any = true;
  secData: any = {};

  secUsersColumn: string[] = ['lastName', 'firstName', 'middleName', 'role', 'action'];
  secUsers: any;

  editedSecId: any;

  users: any;
  user = {
    user_login: '',
    user_password: '',
    user_first_name: '',
    user_second_name: '',
    user_middle_name: '',
    user_confirm: false,
  };
  submitted = false;

  userName = JSON.parse(localStorage.getItem('user'));
  userInfo = JSON.parse(localStorage.getItem('userInfo'));
  active = 1;
  listOfUsers;
  usersList;
  studentsList;
  // roles = [{ id: 'student', name: 'Студент' }, {id: 'secretary', name:'Секретарь'},{id: 'lector',
  // name:'Преподаватель из университета'}, {id: 'head-of-department', name:'Заведующий кафедры'}];
  roles = [{ id: '1', name: 'Студент' }, {id: '3', name: 'Секретарь'}, {id: '4', name: 'Преподаватель'},
    {id: '5', name: 'Заведующий кафедры'}];
  vacancies = [1, 2, 3, 4, 5, 6, 7, 8];
  //lectorsList;
  specialtiesList;
  groupsList: Group[] = [];

  //example
  //groups: Group[] = [];

  animal: string;
  name: string;

  allDiplomWorksList;
  //sec: any = [];


  currentCathedraId:number = this.userInfo.cathedra_id;

  constructor(private admin: AdminService,
              private headOfDepartment: HeadOfDepartmentService,
              private authService: AuthService,
              private router: Router,
              private modalService: NgbModal,
              private restService: RestService,
              private userService: UserService,
              private diplomWork: DiplomWorkService,
              public dialog: MatDialog,
              private groupService: GroupService,
              private specialtyService: SpecialtyService,
              private lectorService: LectorService,
              private secService:SecService,
              private secUserService:SecUserService) { }

  async ngOnInit(): Promise<void> {
    //await this.getAllInfoLectors();
    await this.getInfoLStudents();
    await this.getAllUsersFromCathedra();
    await this.getAllSpecialtiesFromCathedra();
    //await this.getGroupsFromCathedra();
    await this.getNewGroups();
    await this.getAllDiplomWorks();

    //example
    // this.restService.getGroups().subscribe((response) => {
    //   this.groups=response;
    // })

    //this.groups = await this.restService.getGroups();
    //let dataSource = this.groupsList;

    this.specialtyTableData();
    this.groupTableData();
    this.lectorsTableData();
    this.secTableData();
  }

  deleteSecUser(id) {
    this.secUserService.delete(id).
    subscribe((response: any) => {
      this.secUsersTableData();
    }, (error: any)=>{
      console.log(error);
    });
  }

  secUsersTableData() {
    this.secUserService.getAllBySecId(this.editedSecId).
    subscribe((response: any) => {
      this.secUsers = new MatTableDataSource(response);
    }, (error: any)=>{
      console.log(error);
    });
  }

  async openEditSec(id){
    this.isEditSecOpen = !this.isEditSecOpen;
    this.editedSecId = id;
    //this.secId = id;
    //this.secData = await this.secService.getById(id)
    this.getSecById(id)
    console.log(this.secData)
  }

  getSecById(id:any) {
    this.secService.getById(id).
    subscribe((response: any) => {
      this.secData = response
      console.log(this.secData)
    }, (error: any)=>{
      console.log(error);
    });
  }

  specialtyTableData() {
    this.specialtyService.getAllByCathedraId(this.currentCathedraId).
      subscribe((response: any) => {
      this.specialties = new MatTableDataSource(response);
      console.log(this.specialties)
    }, (error: any)=>{
      console.log(error);
    });
  }

  handleEditAction(values:any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      action: 'Edit',
      data: values
    }
    dialogConfig.width = "750px";
    const dialogRef = this.dialog.open(SpecialtyComponent, dialogConfig);
    this.router.events.subscribe(()=>{
      dialogRef.close();
    })
    const sub = dialogRef.componentInstance.onEditSpecialty.subscribe((response)=> {
      this.specialtyTableData();
    })
  }

  handleAddAction() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      action: 'Add'
    }
    dialogConfig.width = "750px";
    const dialogRef = this.dialog.open(SpecialtyComponent, dialogConfig);
    this.router.events.subscribe(()=>{
      dialogRef.close();
    })
    const sub = dialogRef.componentInstance.onAddSpecialty.subscribe((response)=> {
      this.specialtyTableData();
    })
  }

  handleDeleteAction(values:any) {
    // const dialogConfig = new MatDialogConfig();
    // dialogConfig.data = {
    //   message:'delete ' + values.specialty_name
    // };
    // модальное окно, о предупреждении
    // const dialogRef = this.dialog.open(ConfirmationComponent, dialogConfig);
    // const sub = dialogRef.componentInstance.onEmitStatusChange.subscribe((response)=>{
    //   this.ngxService.start();
    //   this.deleteSpecialty(values.specialty_id);
    //   dialogRef.close()
    // })

    this.specialtyService.delete(values.specialty_id).subscribe((response: any) => {
      this.specialtyTableData();
    }, (error: any)=>{
      console.log(error);
    });

  }


  async retrieveUsers() {
    this.userService.getAll()
      .subscribe(
        data => {
          this.users = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

  async getNewGroups() {
    // this.groupsList = await this.groupService.getAllByCathedraId(this.userInfo.cathedra_id)
    // console.log(this.groupsList)
    this.groupService.getAllByCathedraId(this.userInfo.cathedra_id)
      .subscribe(
        data => {
          this.groupsList = data;
          console.log(data);
        },
        error => {
          console.log(error);
        });
  }

/*
  updateGroup(): void {
    const data = {
      group_name: 'myTest',
      fk_specialty: 3
    };
    this.groupService.update(data)
      .subscribe(
        response => {
          console.log(response);
          this.message = 'The group was updated successfully!';
        },
        error => {
          console.log(error);
        });
  }*/

  open(content): void {
    this.modalService.open(content, {ariaLabelledBy: 'modal-basic-title'});
  }
/*
  async getSec(){
    this.sec = await this.secretary.getSec()
  }*/

  async getAllDiplomWorks() {
    console.log("all diplom work")
    this.allDiplomWorksList = await this.diplomWork.getAllDiplomWorksWithInfo()
  }

  async delete(id): Promise<void> {
    await this.admin.deleteUser(id);
    this.listOfUsers =  await this.admin.getAllUsers();
    this.listOfUsers.sort((a, b) => (a.user_first_name > b.user_first_name) ? 1 : -1);
  }

  async confirm(id): Promise<void> {
    await this.admin.confirmUser(id);  // ожидание подтверждения админом пользователя
    await this.getAllUsersFromCathedra();
  }

  async updateRole(id,role){
    await this.admin.updateUserRole(id,role)
    this.listOfUsers =  await this.admin.getAllUsers()
    this.listOfUsers.sort((a, b) => (a.user_first_name > b.user_first_name) ? 1 : -1)
  }

/*
  async getAllInfoLectors() {
    this.lectorsList = await this.headOfDepartment.getInfoLectors(this.userInfo.cathedra_id)
    this.lectorsList.sort((a, b) => (a.user_second_name > b.user_second_name) ? 1 : -1)
  }

 */

  async getInfoLStudents() {
    this.studentsList = await this.headOfDepartment.getInfoStudentsByCathedra(this.userInfo.cathedra_id)
    this.studentsList.sort((a, b) => (a.user_second_name > b.user_second_name) ? 1 : -1)
    console.log(this.studentsList)
  }

  async getAllUsersFromCathedra() {
    this.usersList = await this.headOfDepartment.getUsersByCathedra(this.userInfo.cathedra_id)
    this.usersList.sort((a, b) => (a.user_second_name > b.user_second_name) ? 1 : -1)
  }

  async getAllSpecialtiesFromCathedra() {
    this.specialtiesList = await this.headOfDepartment.getSpecialtiesByCathedra(this.userInfo.cathedra_id)
  }

  async getGroupsFromCathedra() {
    //this.groupsList = await this.headOfDepartment.getGroupsByCathedra(this.userInfo.cathedra_id)
  }

  async deleteSpecialty(specialtyId) {
    await this.headOfDepartment.deleteSpecialty(specialtyId)
    await this.getAllSpecialtiesFromCathedra();
  }

  async addSpecialty(name, fullName, number){
    await this.headOfDepartment.addSpecialty(this.userInfo.cathedra_id, name, fullName, number);
    await this.getAllSpecialtiesFromCathedra()
  }

  async editSpecialty(specialtyId, name, fullName, number){
    await this.headOfDepartment.editSpecialty(specialtyId, name, fullName, number);
    await this.getAllSpecialtiesFromCathedra()
  }

  async filterStudentsByGroupId(groupId) {
    this.studentsList = await this.headOfDepartment.getStudentsByGroupId(this.userInfo.cathedra_id, groupId)
    this.studentsList.sort((a, b) => (a.user_second_name > b.user_second_name) ? 1 : -1)
    console.log(this.studentsList)
  }

  async addGroup(groupName, specialtyId) {
    await this.headOfDepartment.addGroup(groupName, specialtyId);
    await this.getGroupsFromCathedra();
  }

  async deleteGroup(groupId): Promise<void> {
    await this.headOfDepartment.deleteGroup(groupId);
    await this.getGroupsFromCathedra();
  }

  openEdit(content, specialty: Specialty1Model) {
    this.modalService.open(content, {
      centered: true,
      backdrop: 'static',
      size: 'lg'
    });
    document.getElementById('fullName').setAttribute('value', specialty.getFullName());
    document.getElementById('name').setAttribute('value', specialty.getName());
    document.getElementById('number').setAttribute('value', specialty.getSpecialtyNumber());

  }

  groupTableData() {
    this.groupService.getAllByCathedraId(this.currentCathedraId).
    subscribe((response: any) => {
      this.groups = new MatTableDataSource(response);
      console.log(this.groups)
    }, (error: any)=>{
      console.log(error);
    });
  }

  handleAddGroup() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      action: 'Add'
    }
    dialogConfig.width = "750px";
    const dialogRef = this.dialog.open(GroupComponent, dialogConfig);
    this.router.events.subscribe(()=>{
      dialogRef.close();
    })
    const sub = dialogRef.componentInstance.onAddGroup.subscribe((response)=> {
      this.groupTableData();
    })
  }

  handleEditGroup(values:any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      action: 'Edit',
      data: values
    }
    dialogConfig.width = "750px";
    const dialogRef = this.dialog.open(GroupComponent, dialogConfig);
    this.router.events.subscribe(()=>{
      dialogRef.close();
    })
    const sub = dialogRef.componentInstance.onEditGroup.subscribe((response)=> {
      this.groupTableData();
    })
  }

  handleDeleteGroup(values:any) {

  }

  lectorsTableData() {
    this.lectorService.getAll().
    subscribe((response: any) => {
      this.lectors = new MatTableDataSource(response);
      console.log(this.lectors)
    }, (error: any)=>{
      console.log(error);
    });
  }

  handleEditLector(values:any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      action: 'Редактировать',
      data: values
    }
    dialogConfig.width = "400px";
    const dialogRef = this.dialog.open(LectorsComponent, dialogConfig);
    this.router.events.subscribe(()=>{
      dialogRef.close();
    })
    const sub = dialogRef.componentInstance.onEditLector.subscribe((response)=> {
      this.lectorsTableData();
    })
  }

  handleListStudentsAndTopicsAction(values:any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      data: values
    }
    dialogConfig.width = "1000px";
    const dialogRef = this.dialog.open(StudentsListComponent, dialogConfig);
    this.router.events.subscribe(()=>{
      dialogRef.close();
    })
    /*
    const sub = dialogRef.componentInstance.onEditSpecialty.subscribe((response)=> {
      this.specialtyTableData();
    })*/
  }

  secTableData() {
    this.secService.getAll().
    subscribe((response: any) => {
      this.sec = new MatTableDataSource(response);
      console.log(this.sec)
    }, (error: any)=>{
      console.log(error);
    });
  }

  async logoutUser() {
    console.log("Выйти");
    this.authService.logout();
    // TODO: fix URL
    this.router.navigateByUrl(`/login`);
    return false;
  }

  handleAddSec() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      action: 'Добавить'
    }
    dialogConfig.width = "500px";
    const dialogRef = this.dialog.open(SecComponent, dialogConfig);
    this.router.events.subscribe(()=>{
      dialogRef.close();
    })
    const sub = dialogRef.componentInstance.onAddSec.subscribe((response)=> {
      this.secTableData();
    })
  }

  deleteSec(id:any) {
    this.secService.delete(id).
    subscribe((response: any) => {
      this.secTableData();
    }, (error: any)=>{
      console.log(error);
    });
  }

  handleEditSecUser(values:any) {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      action: 'Редактировать',
      data: values
    }
    dialogConfig.width = "750px";
    const dialogRef = this.dialog.open(SecUserComponent, dialogConfig);
    this.router.events.subscribe(()=>{
      dialogRef.close();
    })
    const sub = dialogRef.componentInstance.onEditSecUser.subscribe((response)=> {
      this.secUsersTableData();
    })
  }

  handleAddSecUser() {
    const dialogConfig = new MatDialogConfig();
    dialogConfig.data = {
      action: 'Добавить',
      secId: this.editedSecId
    }
    dialogConfig.width = "750px";
    const dialogRef = this.dialog.open(SecUserComponent, dialogConfig);
    this.router.events.subscribe(()=>{
      dialogRef.close();
    })
    const sub = dialogRef.componentInstance.onAddSecUser.subscribe((response)=> {
      this.secUsersTableData();
    })
  }

}

