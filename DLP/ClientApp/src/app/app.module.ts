import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './home/home.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FooterComponent } from './footer/footer.component';
import { CatalogComponent } from './catalog/catalog.component';
import { AboutComponent } from './about/about.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import {MatToolbarModule} from '@angular/material/toolbar';
import {platformBrowserDynamic} from '@angular/platform-browser-dynamic';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { MatNativeDateModule } from '@angular/material/core';
import {MatMenuModule} from '@angular/material/menu';
import {MatButtonModule} from '@angular/material/button';
import {MatListModule} from '@angular/material/list';
import { HttpClientModule,HttpClient, HTTP_INTERCEPTORS } from '@angular/common/http';
import { ItemComponent } from './item/item.component';
import { AssemblyComponent } from './assembly/assembly.component';
import { ContentService } from './services/content/content.service';
import { HeaderInsterseptor } from './services/content/interseptor.service';
import { Component, Inject, OnInit } from '@angular/core';
import { RouterModule } from '@angular/router';





@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    NavbarComponent,
    FooterComponent,
    CatalogComponent,
    AboutComponent,
    ItemComponent,
    AssemblyComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    //AppRoutingModule,
    BrowserAnimationsModule,
    FormsModule,
    MatNativeDateModule,
    ReactiveFormsModule,
    MatToolbarModule,
    MatMenuModule,
    MatButtonModule,
    MatListModule,
    RouterModule.forRoot([
      { path: 'home', component: HomeComponent },
      { path: 'catalog', component: CatalogComponent },
      { path: 'item', component: ItemComponent },
      { path: 'create_assembly', component: AssemblyComponent },
    ])
  ],
  providers: [
    ContentService,
    /*{ provide: HTTP_INTERCEPTORS, 
      useClass: HeaderInsterseptor,
      multi: true },*/
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
