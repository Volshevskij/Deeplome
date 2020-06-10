import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import {CatalogComponent} from './catalog/catalog.component';
import {ItemComponent} from './item/item.component';
import {AssemblyComponent} from './assembly/assembly.component';
import { AboutComponent } from './about/about.component';
import { CreateAssemblyComponent } from './create-assembly/create-assembly.component';


const routes: Routes = [
  { path: 'home', component: HomeComponent },
  { path: 'catalog', component: CatalogComponent },
  { path: 'item/:id/:type', component: ItemComponent },
  { path: 'create_assembly', component: CreateAssemblyComponent },
  { path: 'ready_assemblies', component: AssemblyComponent },
  { path: 'about', component: AboutComponent },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
