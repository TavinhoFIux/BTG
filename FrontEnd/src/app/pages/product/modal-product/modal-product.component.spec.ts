import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ModalProductComponent } from './modal-product.component';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatInputModule } from '@angular/material/input';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { MAT_DIALOG_DATA, MatDialogModule, MatDialogRef } from '@angular/material/dialog';
import { ProductService } from 'src/app/pages/product/services/product.service';
import { FormControl, FormGroup, FormsModule, ReactiveFormsModule, Validators } from '@angular/forms';

describe('ModalProductComponent', () => {
  let component: ModalProductComponent;
  let fixture: ComponentFixture<ModalProductComponent>;
  let matSnackBarService: MatSnackBar;
  let productService: ProductService;
  const dialogMock = {
    close: () => { }
    };


  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ModalProductComponent],
      imports: [HttpClientTestingModule, 
        MatSnackBarModule, MatToolbarModule, 
        MatInputModule, MatPaginatorModule, 
        MatTableModule, BrowserAnimationsModule , MatDialogModule, FormsModule, ReactiveFormsModule
      ], 
      providers: [                   
        { provide: ProductService},
        { provide: MAT_DIALOG_DATA, useValue: {} },
        { provide: MatDialogRef, useValue: dialogMock },
        { provide: MatSnackBar },
      ]
      
    });
    fixture = TestBed.createComponent(ModalProductComponent);
    component = fixture.componentInstance;
    new FormGroup({
      name: new FormControl('', Validators.required),
    });
    fixture.detectChanges();
    productService = TestBed.inject(ProductService);
    matSnackBarService = TestBed.inject(MatSnackBar);
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Deve testar se botão de adicionar um produto estar funcionando', () => {
    let button = fixture.debugElement.nativeElement.querySelector('button');

    button.click();
  
    fixture.whenStable().then(() => {
      expect(component.submit).toHaveBeenCalled();
    });
  });

  it('Deve testar se metodo de adicionar um produto estar funcionando', () => {
    component.editData = null;
    component.productForm.controls['name'].patchValue("Batata");
    let spy = spyOn(productService, 'createProduct').and.callThrough();

    component.submit();
    
    expect(spy).toHaveBeenCalledTimes(1); 
  });

  it('Deve testar se servico de editar produtor estar sendo chamado', () => {
    component.editData = {id: 10};
    component.productForm.controls['name'].patchValue("Batata");
    let createProductMethod = spyOn(productService, 'createProduct').and.callThrough();
    let editProductMethod = spyOn(productService, 'updateProduct').and.callThrough();

    component.submit();
    
    expect(createProductMethod).toHaveBeenCalledTimes(0); 
    expect(editProductMethod).toHaveBeenCalledTimes(1);
  });

  it('Deve testar se servico de editar produtor estar sendo chamado ocorrer um erro echamar servico SnackBar', () => {
    component.editData = {id: 10};
    component.productForm.controls['name'].patchValue("Batata");
    let createProductMethod = spyOn(productService, 'createProduct').and.callThrough();
    let editProductMethod = spyOn(productService, 'updateProduct').and.throwError("Error");
    let openSnackBar = spyOn(matSnackBarService, 'open').and.callThrough();
    spyOn(component.dialogRef, 'close').and.callThrough();
    
    component.submit();
    
    expect(openSnackBar).toHaveBeenCalledTimes(1);
    expect(createProductMethod).toHaveBeenCalledTimes(0); 
    expect(editProductMethod).toHaveBeenCalledTimes(1);
  });

  it('Deve testar se servico de criar o  produtor estar sendo chamado ocorrer um erro e  chamar servico SnackBar', () => {
    component.editData = null;
    component.productForm.controls['name'].patchValue("Batata");
    let spy = spyOn(productService, 'createProduct').and.throwError("Error");
    let openSnackBar = spyOn(matSnackBarService, 'open').and.callThrough();
    spyOn(component.dialogRef, 'close').and.callThrough();

    component.submit();

    expect(openSnackBar).toHaveBeenCalledTimes(1);
    expect(spy).toHaveBeenCalledTimes(1); 
  });

});
