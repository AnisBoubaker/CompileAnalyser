import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { StatsComponent } from "./stats.component";
import { MatExpansionModule } from "@angular/material/expansion";
import { MatFormFieldModule } from "@angular/material/form-field";
import { MatInputModule } from "@angular/material/input";
import { MatListModule } from "@angular/material/list";

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
