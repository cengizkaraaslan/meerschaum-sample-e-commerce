import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Mothercategory } from '../model/mothercategory';
import { Observable } from 'rxjs';
import { Api } from '../model/api.enum';
@Injectable({
  providedIn: 'root'
})
export class MotherCategoryService {

  constructor(private http: HttpClient) {}
  path = Api.Url + 'mothercategory';
  getCategory(): Observable<Mothercategory[]> {
    return this.http.get<Mothercategory[]>(this.path);
  }
}
