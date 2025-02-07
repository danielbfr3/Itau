using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace EmissaoBoleto
{
    class Program
    {
        static async Task Main(string[] args)
        {
            string token = "token";
            string baseUrl = "https://devportal.itau.com.br/sandboxapi/cash_management_ext_v2/v2";

            var boletoPayload = new
            {
                id_boleto = "b1ff5cc0-8a9c-497e-b983-738904c23386",
                etapa_processo_boleto = "validacao",
                codigo_canal_operacao = "BKL",
                beneficiario = new
                {
                    id_beneficiario = "150000052061",
                    nome_cobranca = "Antonio Coutinho SA",
                    tipo_pessoa = new
                    {
                        codigo_tipo_pessoa = "J",
                        numero_cadastro_pessoa_fisica = "12345678901",
                        numero_cadastro_nacional_pessoa_juridica = "12345678901234"
                    },
                    endereco = new
                    {
                        nome_logradouro = "rua dona ana neri, 368",
                        nome_bairro = "Mooca",
                        nome_cidade = "Sao Paulo",
                        sigla_UF = "SP",
                        numero_CEP = "12345678"
                    }
                },
                dado_boleto = new
                {
                    descricao_instrumento_cobranca = "boleto",
                    tipo_boleto = "proposta",
                    forma_envio = "email",
                    quantidade_parcelas = 2,
                    protesto = new
                    {
                        codigo_tipo_protesto = 1,
                        quantidade_dias_protesto = 1,
                        protesto_falimentar = true
                    },
                    negativacao = new
                    {
                        codigo_tipo_negativacao = 1,
                        quantidade_dias_negativacao = 1
                    },
                    instrucao_cobranca = new[] {
                        new {
                            codigo_instrucao_cobranca = 2,
                            quantidade_dias_instrucao_cobranca = 10,
                            dia_util = true
                        }
                    },
                    pagador = new
                    {
                        id_pagador = "298AFB64-F607-454E-8FC9-4765B70B7828",
                        pessoa = new
                        {
                            nome_pessoa = "Antônio Coutinho",
                            nome_fantasia = "Empresa A",
                            tipo_pessoa = new
                            {
                                codigo_tipo_pessoa = "J",
                                numero_cadastro_pessoa_fisica = "12345678901",
                                numero_cadastro_nacional_pessoa_juridica = "12345678901234"
                            }
                        },
                        endereco = new
                        {
                            nome_logradouro = "rua dona ana neri, 368",
                            nome_bairro = "Mooca",
                            nome_cidade = "Sao Paulo",
                            sigla_UF = "SP",
                            numero_CEP = "12345678"
                        },
                        texto_endereco_email = "itau@itau-unibanco.com.br",
                        numero_ddd = "011",
                        numero_telefone = "27338668",
                        data_hora_inclusao_alteracao = "2016-02-28T16:41:41.090Z"
                    },
                    sacador_avalista = new
                    {
                        pessoa = new
                        {
                            nome_pessoa = "Antônio Coutinho",
                            nome_fantasia = "Empresa A",
                            tipo_pessoa = new
                            {
                                codigo_tipo_pessoa = "J",
                                numero_cadastro_pessoa_fisica = "12345678901",
                                numero_cadastro_nacional_pessoa_juridica = "12345678901234"
                            }
                        },
                        endereco = new
                        {
                            nome_logradouro = "rua dona ana neri, 368",
                            nome_bairro = "Mooca",
                            nome_cidade = "Sao Paulo",
                            sigla_UF = "SP",
                            numero_CEP = "12345678"
                        },
                        exclusao_sacador_avalista = true
                    },
                    codigo_carteira = "112",
                    codigo_tipo_vencimento = 1,
                    valor_total_titulo = "180.00",
                    dados_individuais_boleto = new[] {
                        new {
                            id_boleto_individual = "b1ff5cc0-8a9c-497e-b983-738904c23389",
                            status_boleto = "Simulação Solicitada",
                            situacao_geral_boleto = "Em Aberto",
                            status_vencimento = "a vencer",
                            mensagem_status_retorno = "Data vencimento inválida",
                            numero_nosso_numero = "12345678",
                            dac_titulo = "1",
                            data_vencimento = "2000-01-01",
                            valor_titulo = "180.00",
                            texto_seu_numero = "123",
                            codigo_barras = "34101234567890123456789012345678901234567890",
                            numero_linha_digitavel = "34101234567890123456789012345678901234567890123",
                            data_limite_pagamento = "2000-01-01",
                            mensagens_cobranca = new[] {
                                new {
                                    mensagem = "conceder desconto de R$ 10,00 até a data de vencimento"
                                }
                            },
                            texto_uso_beneficiario = "abc123abc123abc123"
                        }
                    },
                    codigo_especie = "01",
                    descricao_especie = "BDP Boleto proposta",
                    codigo_aceite = "S",
                    data_emissao = "2000-01-01",
                    pagamento_parcial = true,
                    quantidade_maximo_parcial = 2,
                    valor_abatimento = "100.00",
                    juros = new
                    {
                        codigo_tipo_juros = "90",
                        quantidade_dias_juros = 1,
                        valor_juros = "999999999999999.00",
                        percentual_juros = "000000100000",
                        data_juros = "2024-09-21"
                    },
                    multa = new
                    {
                        codigo_tipo_multa = "01",
                        quantidade_dias_multa = 1,
                        valor_multa = "999999999999999.00",
                        percentual_multa = "9999999.00000"
                    },
                    desconto = new
                    {
                        codigo_tipo_desconto = "01",
                        descontos = new[] {
                            new {
                                data_desconto = "2024-09-28",
                                valor_desconto = "999999999999999.00",
                                percentual_desconto = "9999999.00000"
                            }
                        },
                        codigo = "200",
                        mensagem = "Aguardando aprovação",
                        campos = new[] {
                            new {
                                campo = "COD-RET",
                                mensagem = "Processamento efetuado. Aguardando aprovação do gerente",
                                valor = "string"
                            }
                        }
                    },
                    mensagens_cobranca = new[] {
                        new {
                            mensagem = "abc"
                        }
                    },
                    recebimento_divergente = new
                    {
                        codigo_tipo_autorizacao = 1,
                        valor_minimo = "999999999999999.00",
                        percentual_minimo = "9999999.00000",
                        valor_maximo = "999999999999999.00",
                        percentual_maximo = "9999999.00000"
                    },
                    desconto_expresso = true,
                    texto_uso_beneficiario = "726351275ABC",
                    pagamentos_cobranca = new[] {
                        new {
                            codigo_instituicao_financeira_pagamento = "004",
                            codigo_identificador_sistema_pagamento_brasileiro = "341",
                            numero_agencia_recebedora = "1501",
                            codigo_canal_pagamento_boleto_cobranca = "71",
                            codigo_meio_pagamento_boleto_cobranca = "02",
                            valor_pago_total_cobranca = "9999999999999.00",
                            valor_pago_desconto_cobranca = "9999999999999.00",
                            valor_pago_multa_cobranca = "9999999999999.00",
                            valor_pago_juro_cobranca = "9999999999999.00",
                            valor_pago_abatimento_cobranca = "9999999999999.00",
                            valor_pagamento_imposto_sobre_operacao_financeira = "9999999999999.00",
                            data_hora_inclusao_pagamento = "2016-02-28T16:41:41.090Z",
                            data_inclusao_pagamento = "2020-02-28",
                            descricao_meio_pagamento = "DÉBITO EM CONTA",
                            descricao_canal_pagamento = "BANKFONE"
                        }
                    },
                    historico = new[] {
                        new {
                            data = "2020-01-01",
                            operacao = "Alteração dos dados da cobrança",
                            conteudo_anterior = "2020-03-03",
                            conteudo_atual = "2020-04-04",
                            motivo = "Agência informada não existe",
                            comandado_por = 37894,
                            detalhe = new[] {
                                new {
                                    descricao = "ALTERACAO DATA DESCONTO",
                                    conteudo_anterior = "2020-03-03",
                                    conteudo_atual = "2020-04-04"
                                }
                            }
                        }
                    },
                    baixa = new
                    {
                        codigo = "200",
                        mensagem = "Aguardando aprovação",
                        campos = new[] {
                            new {
                                campo = "COD-RET",
                                mensagem = "Processamento efetuado. Aguardando aprovação do gerente",
                                valor = "string"
                            }
                        },
                        codigo_motivo_boleto_cobranca_baixado = "33",
                        indicador_dia_util_baixa = "0",
                        data_hora_inclusao_alteracao_baixa = "2016-02-28T16:41:41.090Z",
                        codigo_usuario_inclusao_alteracao = "000000001",
                        data_inclusao_alteracao_baixa = "2016-02-28"
                    }
                },
                acoes_permitidas = new
                {
                    emitir_segunda_via = true,
                    comandar_instrucao_alterar_dados_cobranca = true
                }
            };

            string jsonPayload = JsonSerializer.Serialize(boletoPayload);

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-sandbox-token", token);
                client.DefaultRequestHeaders.Add("x-itau-correlationID", "cbd05588-4241-350f-a411-b02391475eea");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Ouribank/SGA");

                var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

                HttpResponseMessage response = await client.PostAsync($"{baseUrl}/boletos", content);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Boleto emitido com sucesso:");
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"Erro ao emitir boleto. Status Code: {response.StatusCode}");
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Detalhes do erro:");
                    Console.WriteLine(errorResponse);
                }
            }

            await ConsultarBoletosAsync(token);
        }

        static async Task ConsultarBoletosAsync(string token)
        {
            string baseUrl = "https://devportal.itau.com.br/sandboxapi/cash_management_ext_v2/v2";

            string dataInclusao = DateTime.Today.ToString("yyyy-MM-dd");

            string idBeneficiario = "150000052061";

            string requestUrl = $"{baseUrl}/boletos?id_beneficiario={idBeneficiario}&data_inclusao={dataInclusao}";

            using (var client = new HttpClient())
            {
                client.DefaultRequestHeaders.Add("x-sandbox-token", token);
                client.DefaultRequestHeaders.Add("x-itau-correlationID", "cbd05588-4241-350f-a411-b02391475eea");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.UserAgent.ParseAdd("Ouribank/SGA");

                HttpResponseMessage response = await client.GetAsync(requestUrl);

                if (response.IsSuccessStatusCode)
                {
                    string responseBody = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Consulta de boletos enviados hoje:");
                    Console.WriteLine(responseBody);
                }
                else
                {
                    Console.WriteLine($"Erro na consulta de boletos. Status Code: {response.StatusCode}");
                    string errorResponse = await response.Content.ReadAsStringAsync();
                    Console.WriteLine("Detalhes do erro:");
                    Console.WriteLine(errorResponse);
                }
            }
        }
    }
}
