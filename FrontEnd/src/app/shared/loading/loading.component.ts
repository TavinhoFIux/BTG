import { Component } from '@angular/core';
import { LoadingService } from 'src/app/core/services/loadingService';

@Component({
  selector: 'app-loading',
  templateUrl: './loading.component.html',
  styleUrls: ['./loading.component.scss']
})
export class LoadingComponent {
 
  constructor(public loadingService: LoadingService) {
    
  }

}
