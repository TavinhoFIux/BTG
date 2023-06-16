import {Component, OnInit, ViewChild} from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { Product } from 'src/app/pages/product/types/product';
import { ProductService } from 'src/app/pages/product/services/product.service';
import { MatSort } from '@angular/material/sort';
import { MatPaginator } from '@angular/material/paginator';
import { MatTableDataSource } from '@angular/material/table';
import { ModalProductComponent } from './modal-product/modal-product.component';
import { MatSnackBar } from '@angular/material/snack-bar';


@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.scss']
})
export class ProductComponent implements OnInit {
  displayedColumns: string[] = ['id', 'name', 'action'];
  dataSource: MatTableDataSource<Product>;

  @ViewChild(MatPaginator) paginator: MatPaginator;
  @ViewChild(MatSort) sort: MatSort;

  public constructor(private productService: ProductService, 
    public dialog: MatDialog,
    private snackBar: MatSnackBar) {
  }

  public async ngOnInit(): Promise<void> {
    await this.ToFilTableProduct();
  }

  public applyFilter(event: Event): void {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  public onCreate(): void {
    this.dialog.open(ModalProductComponent, {
      width: '350px',
    }).afterClosed().subscribe(async val => {
      await this.ToFilTableProduct();
    })
  }
  
  public async deleteProduct(id: number): Promise<void> {
    try{
      await this.productService.deleteProduct(id);
    }catch{
      this.snackBar.open('error delete product', 'close');
    }
    await this.ToFilTableProduct();
  }
  
  public editProduct(row: any): void {
    this.dialog.open(ModalProductComponent, {
      width: '350px',
      data: row
    }).afterClosed().subscribe(async val => {
      await this.ToFilTableProduct();
    });
  }

  private async ToFilTableProduct(): Promise<void> {
    try{
      const products = await this.productService.getProducts();
      this.dataSource = new MatTableDataSource(products);
      this.dataSource.paginator = this.paginator;
      this.dataSource.sort = this.sort;
    }catch{
      this.snackBar.open('error getting product', 'close');
    }
  }
}
