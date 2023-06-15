import { LOCALE_ID, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';

import { AppComponent } from './app.component';
import { MenuComponent } from './shared/menu/menu.component';
import { ProductComponent } from './pages/product/product.component';
import { HomeComponent } from './pages/home/home.component';
import { ModalProductComponent } from './pages/product/modal-product/modal-product.component';

import {BrowserAnimationsModule} from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {MatMenuModule} from '@angular/material/menu';
import {MatSidenavModule} from '@angular/material/sidenav';
import {MatIconModule} from '@angular/material/icon';
import {MatButtonModule} from '@angular/material/button';
import {MatProgressSpinnerModule} from '@angular/material/progress-spinner';
import {MatCardModule} from '@angular/material/card';
import {MatListModule} from '@angular/material/list';
import {MatTabsModule} from '@angular/material/tabs';
import {MatDividerModule } from '@angular/material/divider';
import {MatPaginatorModule} from '@angular/material/paginator';
import {MatTableModule} from '@angular/material/table';
import {HttpClientModule } from '@angular/common/http';
import {MatDialogModule} from '@angular/material/dialog';
import {FormsModule, ReactiveFormsModule } from '@angular/forms';
import {MatFormFieldModule } from '@angular/material/form-field';
import {MatInputModule} from '@angular/material/input';
import {MatSortModule } from '@angular/material/sort';
import {MatSnackBarModule} from '@angular/material/snack-bar';



@NgModule({
  declarations: [
    AppComponent,
    MenuComponent,
    ProductComponent,
    HomeComponent,
    ModalProductComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatToolbarModule,
    MatMenuModule,
    MatSidenavModule,
    MatIconModule,
    MatButtonModule,
    MatProgressSpinnerModule,
    MatCardModule,
    MatListModule,
    MatTabsModule,
    MatDividerModule,
    MatTableModule,
    HttpClientModule,
    MatPaginatorModule,
    MatDialogModule,
    FormsModule,
    MatFormFieldModule,
    MatMenuModule, 
    MatInputModule,
    ReactiveFormsModule,
    MatSortModule,
    MatSnackBarModule,
    
  ],
  providers: [
    { provide: LOCALE_ID, useValue: 'pt-BR' }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
