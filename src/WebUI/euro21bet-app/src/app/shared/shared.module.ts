import { CommonModule } from '@angular/common';
import { NgModule } from '@angular/core';
import { ProgressSpinnerModule } from 'primeng/progressspinner';



@NgModule({
	declarations: [
	],
	imports: [
		CommonModule,
		ProgressSpinnerModule,
	],
	exports: [
		CommonModule,
		ProgressSpinnerModule,
	],
	providers: [
	]
})
export class SharedModule { }
