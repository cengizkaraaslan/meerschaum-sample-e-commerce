import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'node_modules/rxjs/Observable';

import { Products } from '../model/products';
import { Category } from '../model/category';
import { Api } from '../model/api.enum';
@Injectable({
  providedIn: 'root'
})
export class CategoryService {
  constructor(private http: HttpClient) {}
  path = Api.Url + 'Category';
  getCategory(mothercategoryid: number): Observable<Category[]> {
    return this.http.get<Category[]>(this.path + '/' + mothercategoryid);
  }
  // getCategoryById(id): Observable<Category> {
  //   return this.http.get<Category>('https://localhost:44326/api/Category/' + id);
  // }
}
