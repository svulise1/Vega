import { NgModule } from '@angular/core';
import { RouterModule } from '@angular/router';
import { AppComponent } from './components/app/app.component'
import { NavMenuComponent } from './components/navmenu/navmenu.component';
import { HomeComponent } from './components/home/home.component';
import { FetchDataComponent } from './components/fetchdata/fetchdata.component';
import { FormsModule } from '@angular/forms';
import { CounterComponent } from './components/counter/counter.component';
import { VechileFormComponent } from './components/vechile-form/vechile-form.component';
import { VechileService } from "./services/vechile.service";
import { ToastyModule } from 'ng2-toasty';
import { VechileListComponent } from "./components/vechile-list/vechile-list.component";
export const sharedConfig: NgModule = {
    bootstrap: [AppComponent],
    declarations: [
        AppComponent,
        NavMenuComponent,
        CounterComponent,
        FetchDataComponent,
        HomeComponent,
        VechileFormComponent,
        VechileListComponent
     
    ],
    imports: [

        RouterModule.forRoot([
            { path: '', redirectTo: 'vechiles', pathMatch: 'full' },
            { path: 'vechiles/new', component: VechileFormComponent },
            { path: 'vechiles/:id', component: VechileFormComponent },
            { path: 'vechiles', component: VechileListComponent },
            { path: 'home', component: HomeComponent },
            { path: 'counter', component: CounterComponent },
            { path: 'fetch-data', component: FetchDataComponent },
            { path: '**', redirectTo: 'home' }
        ]),
        FormsModule,
  

    
    ]
};
