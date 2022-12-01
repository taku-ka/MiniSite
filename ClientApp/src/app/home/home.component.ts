import { HttpClient } from '@angular/common/http';
import { Component, OnInit, Inject } from '@angular/core';
import { NgbModal, NgbModalOptions } from '@ng-bootstrap/ng-bootstrap';

import apiConstant from '../../constants/apiConstant'

import { UpdateComponent } from '../update/update.component';
import { Users } from '../../models/uses.model';
import { GetDataService } from '../../services/getData.services';
import { User } from 'oidc-client';
import { Sort } from '@angular/material/sort';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  title = 'Client';

  searchTerm = '';
  term = '';


  modalOptions: NgbModalOptions = {
    size: 'lg'
  }
 
 
  sortedData: Users[] = [];

  constructor(
    public getDataService: GetDataService,
    private modalService: NgbModal,
    httpClient: HttpClient,
    @Inject('BASE_URL') baseUrl: string)
  {
    httpClient.get<Users[]>(baseUrl + 'userdata').subscribe(result => {
      this.getDataService.allUsers = result;

      this.sortedData = this.getDataService.allUsers.slice();

    }, error => console.error(error));

  }

  onClickBtnUpdateUser(user: User) {
    const modalRef = this.modalService.open(UpdateComponent, this.modalOptions);
    modalRef.componentInstance.user = user;
  }

  sortData(sort: Sort) {
    const data = this.getDataService.allUsers.slice();
   
    if (!sort.active || sort.direction === '') {
      this.sortedData = data;
      return;
    }

    this.sortedData = data.sort((a, b) => {
      const isAsc = sort.direction === 'asc';
      
      switch (sort.active) {
        case 'firstName':
          return compare(a.firstName, b.firstName, isAsc);
        case 'lastName':
          return compare(a.lastName, b.lastName, isAsc);
        case 'dateOfBirth':
          return compare(a.dateOfBirth, b.dateOfBirth, isAsc);
        case 'emailAddress':
          return compare(a.emailAddress, b.emailAddress, isAsc);
        case 'address':
          return compare(a.address, b.address, isAsc);
        case 'city':
          return compare(a.city, b.city, isAsc);
        case 'country':
          return compare(a.country, b.country, isAsc);
        case 'zipCode':
          return compare(a.zipCode, b.zipCode, isAsc);
        default:
          return 0;
      }
    });

  }

 
}
function compare(a: number | string, b: number | string, isAsc: boolean) {
  return (a < b ? -1 : 1) * (isAsc ? 1 : -1);
}


