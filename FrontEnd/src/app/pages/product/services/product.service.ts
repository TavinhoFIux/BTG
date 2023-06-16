import { HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BaseService } from 'src/app/core/services/base.service';
import { HttpService } from 'src/app/core/services/http.service';
import { environment } from 'src/environments/environment';
import { Product } from '../types/product';

@Injectable({
  providedIn: 'root'
})
export class ProductService extends BaseService {

  constructor(private httpService: HttpService) {
    super()
  }

  public async createProduct(name: string): Promise<void> {
    const params = new HttpParams()
    .set('name', name);

    const response = await this.httpService.post(`${this.baseUrl()}/Product`, {params});

    return this.extractData(response);
  }
  
  public async updateProduct(product: any, id: number): Promise<void> {
    const params = new HttpParams()
    .set('id', id)
    .set('name', product.name);

    const response = await this.httpService.put(`${this.baseUrl()}/Product`, {params});

    return this.extractData(response);
  }

  public async deleteProduct(id: number): Promise<void> {
    const params = new HttpParams()
    .set('id', id);

    const response = await this.httpService.delete(`${this.baseUrl()}/Product`, {params});

    return this.extractData(response);
  }

  public async getProducts(): Promise<Product[]> { 

    const url = `${this.baseUrl()}/Product`;

    const response = this.httpService.get(url);

    return this.extractData(response);
  }

}
