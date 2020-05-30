import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import {CatalogComponent} from './catalog/catalog.component';
import {ItemComponent} from './item/item.component';
import {AssemblyComponent} from './assembly/assembly.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'catalog', component: CatalogComponent },
  { path: 'item', component: ItemComponent },
  { path: 'create_assembly', component: AssemblyComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
