import { ComponentFixture, TestBed } from '@angular/core/testing';

import { ProductComponent } from './product.component';
import { ProductService } from 'src/app/features/product/services/product.service';
import { HttpClientTestingModule } from '@angular/common/http/testing';
import { MatDialog } from '@angular/material/dialog';
import { ModalProductComponent } from './modal-product/modal-product.component';
import { MatSnackBar, MatSnackBarModule } from '@angular/material/snack-bar';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatInputModule } from '@angular/material/input';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatTableModule } from '@angular/material/table';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { EMPTY, of } from 'rxjs';

describe('ProductComponent', () => {
  let component: ProductComponent;
  let fixture: ComponentFixture<ProductComponent>;
  let matDialogService: MatDialog;
  let matSnackBarService: MatSnackBar;
  let productService: ProductService;

  const dialogRefStub = {
    afterClosed() {
      return of(true);
    }
  };
  const dialogMock = {
    close: () => {},
    open: () => dialogRefStub
  }


  matSnackBarService = jasmine.createSpyObj<MatSnackBar>('MatSnackBar', ['open']);
  matDialogService = jasmine.createSpyObj<MatDialog>('MatDialog', ['open']);

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [ProductComponent, ModalProductComponent],
      imports: [HttpClientTestingModule, 
        MatSnackBarModule, MatToolbarModule, 
        MatInputModule, MatPaginatorModule, 
        MatTableModule, BrowserAnimationsModule 
      ], 
      providers: [                   
        { provide: ProductService},
        { provide: MatDialog, useValue: dialogMock },
        { provide: MatSnackBar },
    ]
      
    });
    fixture = TestBed.createComponent(ProductComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
    productService = TestBed.inject(ProductService);
    matSnackBarService = TestBed.inject(MatSnackBar);
    matDialogService = TestBed.inject(MatDialog);
    
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  it('Deve testar se botão de criar produto estar funcionando', () => {
  
    let button = fixture.debugElement.nativeElement.querySelector('button');
    button.click();
  
    fixture.whenStable().then(() => {
      expect(component.onCreate).toHaveBeenCalled();
    });
  });

  it('Deve testar se botão de editar estar funcionando', () => {
  
    let button = fixture.debugElement.nativeElement.querySelector('button');
    button.click();
  
    fixture.whenStable().then(() => {
      expect(component.editProduct).toHaveBeenCalled();
    });
  });

  it('Deve testar se botão de deletar estar funcionando', () => {
  
    let button = fixture.debugElement.nativeElement.querySelector('button');
    button.click();
  
    fixture.whenStable().then(() => {
      expect(component.deleteProduct).toHaveBeenCalled();
    });
  });

  it('Deve abrir caixa de diálogo que irar alterar o produto', () => {
    const product = {id: 10, name: "Batata"};
    const dialogSpy = spyOn(dialogMock, 'open').and.returnValue({afterClosed: () => EMPTY} as any);

    component.editProduct(product);
    
    expect(dialogSpy).toHaveBeenCalledTimes(1);
  });

  
  it('Deve testar se servico de deletar produto foi chamado e não ocorreu nenhum error', () => {
    let deleteProductMethod = spyOn(productService, 'deleteProduct').and.callThrough();
    let openSnackBar = spyOn(matSnackBarService, 'open').and.callThrough();
    
    component.deleteProduct(10);

    expect(deleteProductMethod).toHaveBeenCalledTimes(1);
    expect(openSnackBar).toHaveBeenCalledTimes(0);
  });

  it('Deve testar se servico de deletar produto foi chamado e ocorreu um error e servico de error foi chamado', () => {
    let deleteProductMethod = spyOn(productService, 'deleteProduct').and.throwError("Error");
    let openSnackBar = spyOn(matSnackBarService, 'open').and.callThrough();
    
    component.deleteProduct(10);

    expect(openSnackBar).toHaveBeenCalledTimes(1);
    expect(deleteProductMethod).toHaveBeenCalledTimes(1);
  });

  it('Deve abrir caixa de diálogo que irar criar o produto', () => {
    const dialogSpy = spyOn(dialogMock, 'open').and.returnValue({afterClosed: () => EMPTY} as any);

    component.onCreate();
    
    expect(dialogSpy).toHaveBeenCalledTimes(1);
  });

  it('Deve atualizar a tabela de produto quando novo produto for criar', () => {
    const dialogSpy = spyOn(dialogMock, 'open').and.returnValue({afterClosed: () => EMPTY} as any);
    let getProductMethod = spyOn(productService, 'getProducts').and.callThrough();
    let openSnackBar = spyOn(matSnackBarService, 'open').and.callThrough();

    component.onCreate();

    fixture.whenStable().then(() => {
      expect(getProductMethod).toHaveBeenCalledTimes(1);
      expect(dialogSpy).toHaveBeenCalledTimes(1);
      expect(openSnackBar).toHaveBeenCalledTimes(0);
    });
  });

  it('Deve não atualizar a tabela de produto quando ocorrer um erro ao criar um novo produto', () => {
    const dialogSpy = spyOn(dialogMock, 'open').and.returnValue({afterClosed: () => EMPTY} as any);
    let getProductMethod = spyOn(productService, 'getProducts').and.throwError("Error");
    let openSnackBar = spyOn(matSnackBarService, 'open').and.callThrough();

    component.onCreate();

    fixture.whenStable().then(() => {
      expect(getProductMethod).toHaveBeenCalledTimes(1);
      expect(dialogSpy).toHaveBeenCalledTimes(1);
      expect(openSnackBar).toHaveBeenCalledTimes(1);
    });
  });

  it('Deve atualizar a tabela de produto quando um produto for deletado', () => {
    const dialogSpy = spyOn(dialogMock, 'open').and.returnValue({afterClosed: () => EMPTY} as any);
    let getProductMethod = spyOn(productService, 'getProducts').and.callThrough();
    let openSnackBar = spyOn(matSnackBarService, 'open').and.callThrough();

    component.deleteProduct(10);

    fixture.whenStable().then(() => {
      expect(getProductMethod).toHaveBeenCalledTimes(1);
      expect(dialogSpy).toHaveBeenCalledTimes(1);
      expect(openSnackBar).toHaveBeenCalledTimes(0);
    });
  });

  it('Deve não atualizar a tabela de produto quando ocorrer um erro ao deletar um produto', () => {
    const dialogSpy = spyOn(dialogMock, 'open').and.returnValue({afterClosed: () => EMPTY} as any);
    let getProductMethod = spyOn(productService, 'getProducts').and.throwError("Error");
    let openSnackBar = spyOn(matSnackBarService, 'open').and.callThrough();

    component.deleteProduct(10);

    fixture.whenStable().then(() => {
      expect(getProductMethod).toHaveBeenCalledTimes(1);
      expect(dialogSpy).toHaveBeenCalledTimes(1);
      expect(openSnackBar).toHaveBeenCalledTimes(1);
    });
  });

});
