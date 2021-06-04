import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Api } from '../model/api.enum';
import { Undercategory } from '../model/undercategory';

@Injectable({
  providedIn: 'root'
})
export class UnderCategoryService {

  constructor(private http: HttpClient) {}
  path = Api.Url + 'undercategory';
  getCategory(categoryid): Observable<Undercategory[]> {
    return this.http.get<Undercategory[]>(this.path + '/' + categoryid);
  }
}
