import { NgModule } from "@angular/core";
import { MatListModule } from '@angular/material/list';
import { MatInputModule } from '@angular/material/input';

@NgModule({
    exports: [
      MatListModule,
      MatInputModule
    ],
  })
export class MaterialModule {}