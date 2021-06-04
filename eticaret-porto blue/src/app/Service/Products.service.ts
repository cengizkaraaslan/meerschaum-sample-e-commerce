import { Injectable } from '@angular/core';
import {  HttpClient, HttpHeaders  } from '@angular/common/http';
import { Observable } from 'node_modules/rxjs/Observable';

import {   Products } from '../model/products';
import {   Photo } from '../model/Photo';
import { Api } from '../model/api.enum';

@Injectable({
  providedIn: 'root'
})
export class ProductsService {

constructor(private http: HttpClient) { }
 path = Api.Url + 'Products/';
getProduct(): Observable<Products[]> {
    //  const ea =  this.http.get<Products[]>('https://localhost:44326/api/Products').subscribe(
    //     data => {
    //      console.log(data); // My objects array
    //        }

    //     );
   return this.http.get<Products[]>(this.path + 'LatestProduct');
}
topseller(): Observable<Products[]> {
 return this.http.get<Products[]>(this.path + '/Topseller');
}
recentlyViewed(): Observable<Products[]> {
  return this.http.get<Products[]>(this.path + 'RecentlyViewed');
 }
 topNew(): Observable<Products[]> {
  return this.http.get<Products[]>(this.path + 'TopNew');
 }
getProductAlldata(minprice, maxprice, categoryid, orderby , page): Observable<Products[]> {

 return this.http.get<Products[]>(this.path + minprice + '/' + maxprice + '/' + categoryid + '/' + orderby + '/' + page);
}
getProductCount(undercategoryid: number): Observable<number> {
   return this.http.get<number>( this.path + 'count/' + undercategoryid);
 }
getProductById(Product_ID): Observable<Products> {
  return this.http.get<Products>(this.path + Product_ID);
}
getPhotoById(Product_ID): Observable<Photo[]> {
  return this.http.get<Photo[]>( Api.Url + 'photos/' + Product_ID);
}
}
