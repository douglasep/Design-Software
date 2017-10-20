# Este é um exemplo de aplicação do Design Pattern Facade, que verifiquei por Sandy Metz, a um projeto de ruby on rails por exemplo
# A aplicação deste tipo de padrão é ótima para organização do Controller e visualização do mesmo, 
# também pode-se notar que a manutenção fica mais simples e clara.

# Sandy Metz utiliza este padrão para poder utilizar apenas UM objeto por método nos Controllers dela
# Estou aplicando aos meus [def show] pois geralmente é onde utilizo mais

# O simbolo ||= utilizado como "ou" "igual" atribui-se para setar apenas aquele objeto uma vez. Ele só será setado se o mesmo for = nil
# a ||= b =>>>>> a || a = b, ou seja, se a for nil ou falso atribuir o valor de b.

# app/facade/something_facade.rb
class SomethingFacade
    
  initialize something
    @something = something
  end

  def other_object
    @other_object ||= Other_object.find(something.find(params[:id]))
  end

  def another_object
    @another_object ||= Another_object.find(something.find(params[:id]))
  end
    
  private
  
  attr_reader :something

end

# app/controller/something_controllers.rb

class SomethingController < ApplicationController
  def index
    @something = Something.all
  end

  def show
    @something = Something.new(@something) # @something = Something.find(params[:id]) 
  end

end

# Dai a view fica assim
# app/view/something/show.html.erb
[...]
  <h1>
    <%= @something.other_object %>
    <%= @something.another_object %>
  </h1>
[...]
end