import { NgModule } from '@angular/core';
import { SharedModule } from '@app/shared/shared.module';
import { AuthButtonComponent } from './components';
import { TeamListComponent } from './components/team-list/team-list.component';
import { UserMetadataComponent } from './components/user-metadata/user-metadata.component';
import { UserProfileComponent } from './components/user-profile/user-profile.component';
import { TeamListPageComponent } from './pages/team-list-page/team-list-page.component';
import { TeamRoutingModule } from './team-routing.module';
import { TeamComponent } from './team.component';

@NgModule({
	declarations: [
		TeamComponent,
		TeamListComponent,
		TeamListPageComponent,
		AuthButtonComponent,
		UserProfileComponent,
		UserMetadataComponent
	],
	imports: [
		SharedModule,
		TeamRoutingModule,
	]
})
export class TeamModule { }
