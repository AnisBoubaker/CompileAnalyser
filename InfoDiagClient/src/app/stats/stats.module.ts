import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { StatsComponent } from "./stats.component";
import {
  MatExpansionModule,
  MatFormFieldModule,
  MatInputModule,
  MatListModule
} from "@angular/material";

@NgModule({
  declarations: [StatsComponent],
  imports: [
    CommonModule,
    MatExpansionModule,
    MatFormFieldModule,
    MatInputModule,
    MatListModule
  ],
  exports: [StatsComponent]
})
export class StatsModule {}
