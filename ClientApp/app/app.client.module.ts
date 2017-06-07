import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { sharedConfig } from './app.module.shared';
import { MycomponentComponent } from './components/components/mycomponent/mycomponent.component';
import { VechileFormComponent } from './components/vechile-form/vechile-form.component';
import { VechileService } from "./services/vechile.service";

@NgModule({
    bootstrap: sharedConfig.bootstrap,
    declarations: [
       ...sharedConfig.declarations,
       MycomponentComponent,
       VechileFormComponent
       ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        ...sharedConfig.imports
    ],
    providers: [
        { provide: 'ORIGIN_URL', useValue: location.origin },
        VechileService
    ]
})
export class AppModule {
}
