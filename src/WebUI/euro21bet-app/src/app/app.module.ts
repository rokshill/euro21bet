import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';
import { Injector, NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { AuthModule } from '@auth0/auth0-angular';
import { environment } from '@env';
import { MenubarModule } from 'primeng/menubar';
import { TabViewModule } from 'primeng/tabview';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { CoreModule } from './core/core.module';
import { MyAuthHttpInterceptor } from './core/interceptors/my-auth-http.interceptor';
import { AppInjector } from './core/services';
import { FooterComponent } from './layout/footer/footer.component';
import { HeaderComponent } from './layout/header/header.component';
import { NavbarComponent } from './layout/navbar/navbar.component';
import { SharedModule } from './shared/shared.module';

@NgModule({
	declarations: [
		AppComponent,
		HeaderComponent,
		FooterComponent,
		NavbarComponent
	],
	imports: [
		BrowserModule,
		CoreModule,
		SharedModule,
		HttpClientModule,
		AppRoutingModule,
		MenubarModule,
		TabViewModule,
		BrowserAnimationsModule,
		AuthModule.forRoot({
			...environment.auth
		}),

	],
	providers: [{ provide: HTTP_INTERCEPTORS, useClass: MyAuthHttpInterceptor, multi: true },],
	bootstrap: [AppComponent]
})
export class AppModule {
	constructor(protected injector: Injector) {
		AppInjector.setInjector(injector);
	}
}
