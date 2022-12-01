import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { HttpClient, HttpErrorResponse } from '@angular/common/http';

import { NgbActiveModal } from '@ng-bootstrap/ng-bootstrap';
import { GetDataService } from '../../services/getData.services';
import { Users } from '../../models/uses.model';

@Component({
  selector: 'app-modal-update-post',
  templateUrl: './update.component.html',
  styleUrls: ['./update.component.css']
})
export class UpdateComponent implements OnInit {
  public userform!: FormGroup;
  public user!: Users;

  updateSuccessful: boolean = false;
  updateFailed: boolean = false;

  constructor(
    public fb: FormBuilder,
    private httpClient: HttpClient,
    public activeModal: NgbActiveModal,
    private getDataService: GetDataService)
  { }

  ngOnInit(): void {
    this.userform = this.fb.group({
      firstName: [this.user.firstName],
      lastName: [this.user.lastName],
      dateOfBirth: [this.user.dateOfBirth],
      emailAddress: [this.user.emailAddress],
      address: [this.user.address],
      city: [this.user.city],
      country: [this.user.country],
      zipCode: [this.user.zipCode],
       
    });

    this.userform.controls['id'].disable();
  }

}

