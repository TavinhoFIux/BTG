import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpService } from 'src/app/core/services/http.service';
import { environment } from 'src/environments/environment';
import { Product } from '../interfaces/Product';

@Injectable({
  providedIn: 'root'
})
export class ProductService {

  constructor(private httpService: HttpService) {
  }

  public async createProduct(name: string): Promise<void> {
    const params = new HttpParams()
    .set('name', name);

    const response = await this.httpService.post(`${environment.api}/Product`, {params});
    return response
  }
  
  public async updateProduct(product: any, id: number): Promise<void> {
    const params = new HttpParams()
    .set('id', id)
    .set('name', product.name);

    const response = await this.httpService.put(`${environment.api}/Product`, {params});

    return response;
  }

  public async deleteProduct(id: number): Promise<void> {
    const params = new HttpParams()
    .set('id', id);

    const response = await this.httpService.delete(`${environment.api}/Product`, {params});

    return response;
  }

  public async getProducts(): Promise<Product[]> { 
    const url = `${environment.api}/Product`;
    
    const response = this.httpService.get(url);

    return response;
  }


}
