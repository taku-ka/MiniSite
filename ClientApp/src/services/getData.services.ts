import { Injectable } from '@angular/core';
import { Users } from '../models/uses.model';

@Injectable({
  providedIn: 'root'
})
export class GetDataService {

  constructor() { }

  allUsers!: Users[];
}