import { Component, Inject } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { MAT_DIALOG_DATA, MatDialogRef } from '@angular/material/dialog';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ProductService } from 'src/app/features/product/services/product.service';

@Component({
  selector: 'app-modal-product',
  templateUrl: './modal-product.component.html',
  styleUrls: ['./modal-product.component.scss']
})
export class ModalProductComponent {
  public productForm: FormGroup
  public actionButton: string = "Save";

  constructor(public dialogRef: MatDialogRef<ModalProductComponent>, 
    private formBuilder: FormBuilder, 
    private productService: ProductService,
    @Inject(MAT_DIALOG_DATA)public editData: any,
    private snackBar: MatSnackBar) {}


  public ngOnInit(): void {
    this.productForm = this.formBuilder.group({
      name: ['', Validators.required]
    });

    if(this.editData){
      this.actionButton = "Update";
      this.productForm.controls['name'].setValue(this.editData.name);
    }
  
  }

  public async submit(): Promise<void>{
    if(!this.editData){
      if(this.productForm.valid){
        const product = this.productForm.value;
        try{
          await this.productService.createProduct(product.name);
        }catch{
          this.snackBar.open('error add product', 'close');
        }
      }
    }else {
      try{
        await this.productService.updateProduct(this.productForm.value, this.editData.id);
      }catch{
        this.snackBar.open('error update product', 'close');
      }
    }
    this.productForm.reset();
    this.dialogRef.close('update');
  }

}
