import { CommonModule } from '@angular/common';
import '@angular/common/locales/global/pl';
import { LOCALE_ID, NgModule, Optional, SkipSelf } from '@angular/core';
import { ContactPageComponent } from './components/contact-page/contact-page.component';
import { NotFoundPageComponent } from './components/not-found-page/not-found-page.component';
import { throwIfAlreadyLoaded } from './utils';

@NgModule({
	declarations: [
		NotFoundPageComponent,
		ContactPageComponent
	],
	imports: [
		CommonModule,
	],
	providers: [
		{ provide: LOCALE_ID, useValue: 'pl-PL' }
	]
})
export class CoreModule {
	constructor(@Optional() @SkipSelf() parentModule: CoreModule) {
		throwIfAlreadyLoaded(parentModule, 'CoreModule');
	}
}
