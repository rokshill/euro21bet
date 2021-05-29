import { NgModule, Optional, SkipSelf } from '@angular/core';
import { CommonModule } from '@angular/common';
import { throwIfAlreadyLoaded } from './utils';
import { NotFoundPageComponent } from './components/not-found-page/not-found-page.component';
import { ContactPageComponent } from './components/contact-page/contact-page.component';

@NgModule({
	declarations: [
		NotFoundPageComponent,
		ContactPageComponent
	],
	imports: [
		CommonModule,
	]
})
export class CoreModule {
	constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
		throwIfAlreadyLoaded(parentModule, 'CoreModule');
	}
}
