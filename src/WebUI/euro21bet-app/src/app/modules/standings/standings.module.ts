import { NgModule } from '@angular/core';
import { SharedModule } from '@app/shared/shared.module';
import { StandingsPageComponent } from './pages/standings-page/standings-page.component';
import { StandingsRoutingModule } from './standings-routing.module';
import { StandingsComponent } from './standings.component';



@NgModule({
	declarations: [
		StandingsComponent,
		StandingsPageComponent
	],
	imports: [
		SharedModule,
		StandingsRoutingModule,
	]
})
export class StandingsModule { }
