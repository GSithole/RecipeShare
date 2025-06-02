import {NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { CreateComponent } from './create/create.component';
import { EditComponent } from './edit/edit.component';
import { DetailsComponent } from './details/details.component';

const routes: Routes = [
  {path:'recipe/home',component:HomeComponent},
    {path:'recipe', redirectTo:'recipe/home',pathMatch:'full' },
    {path:'', redirectTo:'recipe/home',pathMatch:'full'},
    {path:'recipe/create', component:CreateComponent},
    {path: 'recipe/edit/:recipeId',component:EditComponent},
    {path:'recipe/details/:recipeId',component:DetailsComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class RecipeRoutingModule { }
