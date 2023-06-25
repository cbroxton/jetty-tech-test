import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './features/home/components/home/home.component';
import { NotFoundComponent } from './core/components/not-found/not-found/not-found.component';
import { ErrorPageComponent } from './core/components/error-page/error-page.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: '404', component: NotFoundComponent },
  { path: 'error', component: ErrorPageComponent },
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(
    routes,
    {
      bindToComponentInputs: true
    }
  )],
  exports: [RouterModule]
})
export class AppRoutingModule { }
