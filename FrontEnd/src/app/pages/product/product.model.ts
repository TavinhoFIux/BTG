import { NgModule } from "@angular/core";
import { ModalProductComponent } from "./modal-product/modal-product.component";
import { CommonModule } from "@angular/common";
import { ProductComponent } from "./product.component";
import { FormsModule, ReactiveFormsModule } from "@angular/forms";
import { ProductService } from "./services/product.service";
import { MatButtonModule } from "@angular/material/button";
import { MatDialogModule } from "@angular/material/dialog";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatIconModule } from "@angular/material/icon";
import { MatInputModule } from "@angular/material/input";
import { MatPaginatorModule } from "@angular/material/paginator";
import { MatSnackBarModule } from "@angular/material/snack-bar";
import { MatTableModule } from "@angular/material/table";
import { MatToolbarModule } from "@angular/material/toolbar";

@NgModule({
    imports: [ 
        CommonModule,
        FormsModule,
        ReactiveFormsModule,
        MatSnackBarModule,
        MatFormFieldModule,
        MatInputModule,
        MatPaginatorModule,
        MatDialogModule,
        MatToolbarModule,
        MatIconModule,
        MatButtonModule,
        MatTableModule,
    ],
    exports: [],
    declarations: [
        ModalProductComponent,
        ProductComponent
    ],
    providers: [ProductService]

})

export class ProductModel {}