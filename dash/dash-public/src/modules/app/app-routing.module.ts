import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { PageOneComponent } from './page-one/page-one.component'
import { PageTwoComponent } from './page-two/page-two.component'
import { PageThreeComponent } from './page-three/page-three.component'


const routes: Routes = [
  { path: '', redirectTo: '/one', pathMatch: 'full' },
  { path: 'one', component: PageOneComponent },
  { path: 'two', component: PageTwoComponent },
  { path: 'three', component: PageThreeComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }