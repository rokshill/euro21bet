import { NgModule } from '@angular/core';
import { SharedModule } from '@app/shared/shared.module';
import { MatchRoutingModule } from './match-routing.module';
import { MatchComponent as MatchComponent } from './match.component';
import { MatchListPageComponent } from './pages/match-list-page/match-list-page.component';


@NgModule({
	declarations: [
		MatchComponent,
		MatchListPageComponent
	],
	imports: [
		SharedModule,
		MatchRoutingModule,
	]
})
export class MatchModule { }
